using Core.Constants;
using Core.Helper;
using Manage.Controller;
using System;

public class Program
{
    static void Main()
    {
        OwnerController _ownerController = new OwnerController();
        DrugStoreController _drugStoreController = new DrugStoreController();
        DrugController _drugController = new DrugController();
        DrugGistController _drugGistController = new DrugGistController();
        AdminController _adminController = new AdminController();


    Authentication: var admin = _adminController.Authenticate();

        if (admin != null)
        {

            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Welcome => {admin.Username}");

            

            while (true)
            {

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Main Menu");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "------------");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "1) - Owners");               
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "2) - Drugstores");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "3) - Drugs");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "4) - Druggists");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "5) - Logout");

                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "--------------");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Select Number");
                string number = Console.ReadLine();
                int SelectedNumber;
                bool result = int.TryParse(number, out SelectedNumber);

                if (result)
                {

                    if (SelectedNumber == 1)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "1) - Create Owner");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "2) - Update Owner");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "3) - Delete Owner");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "4) - Get All Owner");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "0) - Main Menu");

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Select Option");
                        number = Console.ReadLine();
                        result = int.TryParse(number, out SelectedNumber);

                        if (SelectedNumber >= 0 && SelectedNumber <= 4)
                        {
                            switch (SelectedNumber)
                            {
                                case (int)Options.CreateOwner:
                                    _ownerController.CreateOwner();
                                    break;
                                case (int)Options.UpdateOwner:
                                    _ownerController.Update();
                                    break;
                                case (int)Options.DeleteOwner:
                                    _ownerController.Delete();
                                    break;
                                case (int)Options.GetAllOwner:
                                    _ownerController.GetAll();
                                    break;

                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter correct number !");
                        }

                    }
                    else if (SelectedNumber == 2)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "5) - Create Drugstore");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "6) - Update Drugstore");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "7) - Delete Drugstore");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "8) - Get All Drugstore");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "9) - Get All Drugstores By Owner");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "10) - Sale");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "0) -  Main Menu");

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Select Option");
                        number = Console.ReadLine();
                        result = int.TryParse(number, out SelectedNumber);
                        if (SelectedNumber >= 0 && SelectedNumber <= 11)
                        {
                            switch (SelectedNumber)
                            {
                                case (int)Options.CreateDrugStore:
                                    _drugStoreController.Create();
                                    break;
                                case (int)Options.UpdateDrugStore:
                                    _drugStoreController.Update();
                                    break;
                                case (int)Options.DeleteDrugStore:
                                    _drugStoreController.Delete();
                                    break;
                                case (int)Options.GetAllDrugStore:
                                    _drugStoreController.GetAll();
                                    break;
                                case (int)Options.GetAllDrugStoresByOwner:
                                    _drugStoreController.GetAllDrugStoresByOwner();
                                    break;
                                case (int)Options.Sale:
                                    _drugStoreController.Sale();
                                    break;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter correct number !");

                        }

                    }
                    else if (SelectedNumber == 3)
                    {

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "11) - Create Drugs");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "12) - Update Drugs");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "13) - Delete Drugs");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "14) - Get All Drugs");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "15) - Get All Drugs By Drugstore");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "16) - Filter");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "0)  - Main Menu");

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Select Option");
                        number = Console.ReadLine();
                        result = int.TryParse(number, out SelectedNumber);
                        if (SelectedNumber >= 0 && SelectedNumber <= 16)
                        {
                            switch (SelectedNumber)
                            {
                                case (int)Options.CreateDrugs:
                                    _drugController.Create();
                                    break;
                                case (int)Options.UpdateDrugs:
                                    _drugController.Update();
                                    break;
                                case (int)Options.DeleteDrugs:
                                    _drugController.Delete();
                                    break;
                                case (int)Options.GetAllDrugs:
                                    _drugController.GetAll();
                                    break;
                                case (int)Options.GetAllDrugsByDrugStore:
                                    _drugController.GetAllDrugsByDrugStore();
                                    break;
                                case (int)Options.Filter:
                                    _drugController.DrugFIlter();
                                    break;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter correct number !");

                        }
                    }
                    else if (SelectedNumber == 4)
                    {


                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "17) - Create Druggist");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "18) - Update Druggist");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "19) - Delete Druggist");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "20) - Get all druggist");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "21) - Get all druggist by drugstore");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "0)  - Main Menu");

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Select Option");
                        number = Console.ReadLine();
                        result = int.TryParse(number, out SelectedNumber);
                        if (SelectedNumber >= 0 && SelectedNumber <= 21)
                        {
                            switch (SelectedNumber)
                            {
                                case (int)Options.CreateDrugGist:
                                    _drugGistController.Create();
                                    break;
                                case (int)Options.UpdateDrugGist:
                                    _drugGistController.Update();
                                    break;
                                case (int)Options.DeleteDrugGist:
                                    _drugGistController.Delete();
                                    break;
                                case (int)Options.GetAllDrugGist:
                                    _drugGistController.GetAll();
                                    break;
                                case (int)Options.GetAllDrugGistByDrugStore:
                                    _drugGistController.GetAllDrugGistByDrugstore();
                                    break;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter correct number !");

                        }

                    }
                    else if (SelectedNumber == 5)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "22) - Logout user");
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "0)  - Main Menu");

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Select Option");
                        number = Console.ReadLine();
                        result = int.TryParse(number, out SelectedNumber);
                        if (SelectedNumber >= 0 && SelectedNumber <= 22)
                        {
                            switch (SelectedNumber)
                            {
                                case (int)Options.Logout:
                                    _adminController.LogOut();
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Please, enter correct number!");
                }
            }
        }
        else
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "Admin username or password is incorrect");
            goto Authentication;
        }

    }
}



