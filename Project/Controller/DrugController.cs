using Core.Entities;
using Core.Helper;
using DataAccess.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Controller
{
    public class DrugController
    {
        private DrugRepository _drugRepository;
        private DrugStoreRepository _drugStoreRepository;

        public DrugController()
        {

            _drugRepository = new DrugRepository();
            _drugStoreRepository = new DrugStoreRepository();

        }
        #region CreateDrug
        public void Create()
        {
            var drugStores = _drugStoreRepository.GetAll();
            if (drugStores.Count != 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter drug name");
                string name = Console.ReadLine();
            Count: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter drug count");
                string count = Console.ReadLine();
                int chosenCount;
                var result = int.TryParse(count, out chosenCount);
                if (result)
                {
                Price: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter drug price");
                    string price = Console.ReadLine();
                    double chosenPrice;
                    var result1 = double.TryParse(price, out chosenPrice);
                    if (result1)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All Drugstores");
                        foreach (var drugstore in drugStores)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"ID - {drugstore.ID} Name - {drugstore.Name} Address-{drugstore.Address}");

                        }
                    ChosenId: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Drugstore ID:");
                        string id = Console.ReadLine();
                        int chosenId;
                        var result2 = int.TryParse(id, out chosenId);
                        if (result2)
                        {
                            var dbStore = _drugStoreRepository.Get(d => d.ID == chosenId);
                            if (dbStore != null)
                            {
                                Drug drug = new Drug
                                {
                                    Name = name,
                                    Price = chosenPrice,
                                    Count = chosenCount,


                                };
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no Drugstore with this ID");
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter Id in correct format");
                            goto ChosenId;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter price with correct format");
                        goto Price;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter count with correct format");
                    goto Count;
                }




            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"You must create owner before creating of drugstore");
            }






        }
        #endregion

        #region UpdateDrug
        public void Update()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All Drugs");
                foreach (var drug in drugs)
                {

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"DragStoreID - {drug.DrugStore.ID} Drugstore Name-{drug.DrugStore.Name}, Name - {drug.Name} Count-{drug.Count} Price-{drug.Price}");

                }
                Id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter drugstore ID");
                string Id = Console.ReadLine();
                int storeId;
                var result=int.TryParse(Id, out storeId);
                if (result)
                {
                    var drugstore = _drugStoreRepository.GetAll();
                    if (drugstore!=null)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Enter new drug name");
                        string name = Console.ReadLine();
                        CountFormat: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Enter new drug count");
                        string count = Console.ReadLine();
                        int chosenCount;
                        var result1 = int.TryParse(count, out chosenCount);
                        if (result)
                        {
                            PriceFormat: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter new drug price");
                            string price= Console.ReadLine();
                            double chosenPrice;
                            var result2 = double.TryParse(price, out chosenPrice);
                            if (result2)
                            {
                                var updatedDrugs = new Drug
                                {
                                    Name = name,
                                    Price = chosenPrice,
                                    Count=chosenCount,
                                

                                };
                                _drugRepository.Update(updatedDrugs);
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{updatedDrugs.Name}  {updatedDrugs.Count}  {updatedDrugs.Price} are successfully updated");
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter price In correct format");
                                goto PriceFormat;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter count In correct format");
                            goto CountFormat;
                        }


                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is nor drugstore with this ID");
                    }
                    
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter Id in correct format");
                    goto Id;
                }
               

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any Drugs");
            }

        }
        #endregion

        #region Delete
        public void Delete()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count>0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All Drugs list");
                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, $"Drugstore ID-{drug.DrugStore.ID} Drugstore Name{drug.DrugStore.Name} Drug Name-{drug.Name} Drug COunt-{drug.Count} Drug Price-{drug.Price}");
                }
                CorrectId: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Drugstore Id");
                string id = Console.ReadLine();
                int drugstoreID;
                var result = int.TryParse(id, out drugstoreID);
                if (result)
                {
                    var drug = _drugRepository.Get(d => d.ID == drugstoreID);
                    if (drug != null)
                    {
                        string fullinfo = $"{drug.Name} {drug.Price} {drug.Count}";
                        _drugRepository.Delete(drug);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{fullinfo} is deleted succesfully ");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Drug doesn't exist with this ID");
                    }

                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter ID in corect format");
                    goto CorrectId;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There are no any Drugs");
                
            }
            
        }
        #endregion

        #region GetAll
        public void GetAll()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All Drugs list");
                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, $"Drugstore Information - {drug.DrugStore.Name} {drug.DrugStore.ID} Drugs Information - {drug.Name} {drug.Price} {drug.Count}");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There are not any drugs");
            }
        }
        #endregion
        #region GetAllDrugsByDrugStore
        public void GetAllDrugsByDrugStore()
        {
            var drugstores = _drugStoreRepository.GetAll();
            if (drugstores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "All Drugstores list");
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Drugstore ID - {drugstore.ID} Drugstore Name- {drugstore.Name} Drugstore Address {drugstore.Address} {drugstore.ContactNumber}");
                }
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter drugstore ID");
                string id = Console.ReadLine();
                int drugstoreID;
                bool result = int.TryParse(id, out drugstoreID);
                if (result)
                {
                    var dbDrugStore = _drugStoreRepository.Get(d => d.ID == drugstoreID);
                    if (dbDrugStore != null)
                    {
                        var drugs = _drugRepository.GetAll(d => d.ID == drugstoreID);
                        if (drugs.Count > 0)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "All drugs of drugstore");
                            foreach (var drug in drugs)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"ID - {drug.ID} Name - {drug.Name}");
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "The drugstore has no drugs");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Drugstore doesn't exist with this ID");
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter ID in correct format");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There are not any drugstores");
            }
        }
        #endregion






    }
}


