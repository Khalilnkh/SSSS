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
            var drugstores = _drugStoreRepository.GetAll();

            if (drugstores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please , enter drug name :");
                string drugName = Console.ReadLine();
            drugPrice: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please , enter drug price:");
                string priceDrug = Console.ReadLine();
                double price;
                bool result = double.TryParse(priceDrug, out price);
                if (result)
                {
                drugCount: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please , enter drug count:");
                    string countDrug = Console.ReadLine();
                    int count;
                    result = int.TryParse(countDrug, out count);

                    if (result)
                    {

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All drugstores:");
                        foreach (var drugstore in drugstores)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, $"id : {drugstore.ID} , name : {drugstore.Name} , adress : {drugstore.Address} , contactNumber:{drugstore.ContactNumber} ");
                        }
                    DrugstoreId: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Please , enter drugstore id :");
                        string storeId = Console.ReadLine();
                        int id;
                        result = int.TryParse(storeId, out id);
                        if (result)
                        {
                            var drugStore = _drugStoreRepository.Get(d => d.ID == id);
                            if (drugStore != null)
                            {
                                var drug = new Drug
                                {
                                    Name = drugName,
                                    Price = price,
                                    Count = count,
                                    DrugStore = drugStore,
                                };
                                _drugRepository.Create(drug);
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"name : {drugName} , price : {priceDrug} , count : {count} , drugstore : {drug.DrugStore.Name} is created drug");

                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This drugstore is empty");
                                goto DrugstoreId;
                            }


                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format Id");
                            goto DrugstoreId;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please , enter drug count in correct format !");
                        goto drugCount;
                    }

                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please , enter price in correct format !");
                    goto drugPrice;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drugstore");
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

        public void DrugFIlter()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count>0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Please enter filter price");
                string price = Console.ReadLine();
                double priceOfFilter;
                bool result=double.TryParse(price, out priceOfFilter);
                if (result)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Please enter all drugs List");
                    foreach (var drug in drugs)
                    {
                        if (drug.Price<=priceOfFilter)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, $"Drug ID-{drug.ID} Name-{drug.Name} Price-{drug.Price} Count-{drug.Count}");
                        }
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter price in correct format");
                }


            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There are no any drugs");
            }
        }







    }
}


