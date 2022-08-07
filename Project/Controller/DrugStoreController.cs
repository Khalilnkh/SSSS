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
    public class DrugStoreController
    {
        private DrugStoreRepository _drugStoreRepository;
        private OwnerRepository _ownerRepository;
        private DrugRepository _drugRepository;
        public DrugStoreController()
        {
            _drugStoreRepository = new DrugStoreRepository();
            _ownerRepository = new OwnerRepository();
            _drugRepository = new DrugRepository();
        }

        public void Create()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count != 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter drugstore name");
                string name = Console.ReadLine();

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter drugstore address");
                string address = Console.ReadLine();

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter drugstore contact number");
                string number = Console.ReadLine();

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All owners");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"ID - {owner.ID} Fullname - {owner.Name} {owner.Surname}");
                }
            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter owner ID:");
                string id = Console.ReadLine();
                int ownerID;
                bool result = int.TryParse(id, out ownerID);
                if (result)
                {
                    var dbOwner = _ownerRepository.Get(o => o.ID == ownerID);

                    if (dbOwner != null)
                    {
                        DrugStore drugStore = new DrugStore
                        {
                            Name = name,
                            Address = address,
                            ContactNumber = number,
                            Owner = dbOwner,
                        };

                        _drugStoreRepository.Create(drugStore);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name:{drugStore.Name} Address:{drugStore.Address} ContactNumber:{drugStore.ContactNumber} Owner:{drugStore.Owner.Name}");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, $"Owner doesn't exist with this ID");
                        goto ID;

                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter owner ID in correct format");
                    goto ID;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, $"You must create owner before creating of drugstore");
            }

        }

        public void Update()
        {
            var drugStores = _drugStoreRepository.GetAll();
            if (drugStores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All list");
                foreach (var drugstore in drugStores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"Drugstore owner ID - {drugstore.Owner.ID} Drugstore owner Name - {drugstore.Owner.Name} All info - {drugstore.Name} {drugstore.Address} {drugstore.ContactNumber}");
                }
            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkYellow, "Enter owner ID");
                string id = Console.ReadLine();
                int ownerID;
                bool result = int.TryParse(id, out ownerID);
                if (result)
                {
                    var dbDrugStore = _drugStoreRepository.Get(d => d.ID == ownerID);
                    if (dbDrugStore != null)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter drugstore new name");
                        string DbName = Console.ReadLine();

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter drugstore new address");
                        string DbAddress = Console.ReadLine();

                    ContactNumber: ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Enter drugstore new contact number");
                        string DbNumber = Console.ReadLine();

                        var updatedStore = new DrugStore
                        {
                            Name =DbName,
                            Address = DbAddress,
                            ContactNumber = DbNumber,
                        };
                        _drugStoreRepository.Update(updatedStore);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{updatedStore.Name} {updatedStore.Address} {updatedStore.ContactNumber} is updated to successfully");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Owner doesn't exist with this ID");
                        goto ID;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Enter ID in correct format");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "There are not any owner");
            }
        }

        public void Delete()
        {
            var drugStores = _drugStoreRepository.GetAll();
            if (drugStores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "All drugstore list");
                foreach (var drugstore in drugStores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $" Drugstore owner info - {drugstore.Owner.ID} {drugstore.Owner.Name}, All info - {drugstore.Name} {drugstore.Address} {drugstore.ContactNumber}");
                }
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter owner ID");
                string id = Console.ReadLine();
                int ownerID;
                var result = int.TryParse(id, out ownerID);
                if (result)
                {
                    var drugstore = _drugStoreRepository.Get(o => o.ID == ownerID);
                    if (drugstore != null)
                    {
                        string allInfo = $"{drugstore.Name} {drugstore.Address}";
                        _drugStoreRepository.Delete(drugstore);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{allInfo} is deleted  ");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Drugstore doesn't exist with this ID");
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter ID in correct format");
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There are not any drugstore");
            }
        }

        public void GetAll()
        {
            var drugStores = _drugStoreRepository.GetAll();
            if (drugStores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "All drugstore list");
                foreach (var drugstore in drugStores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Owner - {drugstore.Owner.Name} All info - {drugstore.Name} {drugstore.Address} {drugstore.ContactNumber}");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is not any drugstores");
            }
        }

        public void GetAllDrugStoresByOwner()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "All owner list");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"ID -- {owner.ID}, Fullname - {owner.Name} {owner.Surname}");
                }
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter owner ID");
                string id = Console.ReadLine();
                int ownerID;
                var result = int.TryParse(id, out ownerID);
                if (result)
                {
                    var dbOwner = _ownerRepository.Get(o => o.ID == ownerID);
                    if (dbOwner != null)
                    {
                        var ownerDrugStore = _drugStoreRepository.GetAll(o => o.Owner.ID == ownerID);
                        if (ownerDrugStore.Count != 0)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "All drugstore of the owner");
                            foreach (var ownerdrugstore in ownerDrugStore)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"ID - {ownerdrugstore.ID} Drugstore Name  - {ownerdrugstore.Name} Drugstore Address {ownerdrugstore.Address}");
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no owner in this drugstore");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Including owner doesn't exist");
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter ID in correct format");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "There is not any owner");
            }
        }

        public void Sale()
        {
            GetAll();
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Please choose drugstore Id");
            string id = Console.ReadLine();
            int drugStoreID;
            var result = int.TryParse(id, out drugStoreID);
            if (result)
            {
                var dbdrugStore = _drugStoreRepository.Get(d => d.ID == drugStoreID);
                if (dbdrugStore!=null)
                {
                    var dbDrugs = _drugRepository.GetAll(d => d.DrugStore == dbdrugStore);
                    if (dbDrugs.Count>0)
                    {
                        foreach (var drug in dbDrugs)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, $"  Drug Id:{drug.ID} Drug name-{drug.Name} Drug price-{drug.Price} Drug COunt {drug.Count}");

                        }
                         checkId: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Please enter drug Id");
                        string drugId = Console.ReadLine();
                        int chosenDrugId;
                        var result1=int.TryParse(drugId, out chosenDrugId);
                        if (result1)
                        {
                            var dbdrug=_drugRepository.Get(d=>d.ID==chosenDrugId);
                            if (dbdrug!=null&&dbdrug.Count>0)
                            {
                                correctCount: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, $"Drug Count-{dbdrug.Count} please enter drug count");
                                var count = Console.ReadLine();
                                int dbcount;
                                var results=int.TryParse(count,out dbcount);
                                if (results)
                                {
                                    if (dbcount<=dbdrug.Count)
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, $"Sale Price {dbcount * dbdrug.Price}");
                                        dbdrug.Count-=dbcount;
                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter");
                                    }

                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter drug count in correct format");
                                    goto correctCount;
                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Something went wrong");
                            }

                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter drug Id in correct format");
                            goto checkId;
                        }

                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drugstore");
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drugstore with this id");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter Id in correct format");
            }
        }
    }
}
