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
        AdminController _adminController = new AdminController();


       Authentication: var admin = _adminController.Authenticate();

        if (admin != null)
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Welcome, {admin.Username}");
            Console.WriteLine("------------");

            while (true)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "1 - Create Owner");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "2 - Update Owner");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "3 - Delete Owner");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "4 - Get All Owner");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "5 - Create Drugstore");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "6 - Update Drugstore");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "7 - Delete Drugstore");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "8 - Get All Drugstore");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "9 - Get All Drugstores By Owner");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "10 - Sale");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "11 - Create Drugs");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "12 - Update Drugs");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "13 - Delete Drugs");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "14 - Get All Drugs");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "15 - Get All Drugs By Drugstore");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "16 - Filter");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "17 - Create Druggist");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "18 - Update Druggist");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "19 - Delete Druggist");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "20 - Get all druggist");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "21 - Get all druggist by drugstore");
                Console.WriteLine("-------");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Select Options");
                string number = Console.ReadLine();

                int SelectedNumber;
                bool result = int.TryParse(number, out SelectedNumber);


                if (result)
                {
                    if (SelectedNumber >= 0 && SelectedNumber <= 21)
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
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct number!");
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter number in correct format !");
                }


            }
        
        }
        else
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "PLease enter correct login and password");
            goto Authentication;
        }
    }
}

