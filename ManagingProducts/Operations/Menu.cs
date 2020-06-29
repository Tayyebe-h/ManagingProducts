using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;


namespace ManagingProducts.Operations
{
    public static class Menu
    {
        static int option = 0;

        public static void ConsoleMenu()
        {
            Console.WriteLine(" ");
            Console.WriteLine(" Choose one of the options! ");
            Console.WriteLine(" ");
            Console.WriteLine("1.Information in Database ");
            Console.WriteLine("2.Add a product ");
            Console.WriteLine("3.Update the information of a product such as deleting or adding the stores. ");
            Console.WriteLine("4.Delete a product ");
            Console.WriteLine("5.Search for a product by its Id");
            Console.WriteLine("6.Search for a product by its name");
            Console.WriteLine("7.List of all of the stores with their products");
            Console.WriteLine("8.List of products of a store");
            Console.WriteLine("9.Add a store with its products");
            Console.WriteLine("10.Add some products to a store");
            Console.WriteLine("11.Delete a store ");
            Console.WriteLine("12.Search for products cheaper than a special price ");
            Console.WriteLine("13.Search for all the stores which have a special product ");
            Console.WriteLine("14.List of all manufacures and the number of their products. ");
            Console.WriteLine("15.Exit ");
            Console.WriteLine(" ");
            option = GetOptionNum();
        }

        public static void Run()
        {
            switch (option)
            {
                case 0:
                    Console.WriteLine("No option is chosen!");
                    break;
                case 1:
                    Option1();
                    break;
                case 2:
                    Option2();
                    break;
                case 3:
                    Option3();
                    break;
                case 4:
                    Option4();
                    break;
                case 5:
                    Option5();
                    break;
                case 6:
                    Option6();
                    break;
                case 7:
                    Option7();
                    break;
                case 8:
                    Option8();
                    break;
                case 9:
                    Option9();
                    break;
                case 10:
                    Option10();
                    break;
                case 11:
                    Option11();
                    break;
                case 12:
                    Option12();
                    break;
                case 13:
                    Option13();
                    break;
                case 14:
                    Option14();
                    break;
                case 15:
                    Environment.Exit(0);
                    break;
            }
        }


        static int GetOptionNum()
        {
            while (true)
            {
                string num;
                int num1;
                try
                {
                    num = Console.ReadLine();
                    num1 = Convert.ToInt32(num);

                    if (num1 >= 1 && num1 <= 15)
                    {
                        return num1;
                    }
                    else
                        throw new Exception(" Enter the number of an option!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        static void Option1()
        {
            ProductOperations.Database();
        }

        static void Option2()
        {
            ProductOperations.AddProduct();
        }

        static void Option3()
        {
            ProductOperations.UpdateAProduct();
        }

        static void Option4()
        {
            ProductOperations.DeleteProduct();
        }

        static void Option5()
        {
            ProductOperations.SearchProductById();
        }

        static void Option6()
        {
            ProductOperations.SearchByName();
        }

        static void Option7()
        {
            StoreOperations.ListAllStores();
        }

        static void Option8()
        {
            StoreOperations.ListaStoresProducts();
        }

        static void Option9()
        {
            StoreOperations.AddaStore();
        }

        static void Option10()
        {
            StoreOperations.UpdateaStore();
        }

        static void Option11()
        {
            StoreOperations.DeleteStore();
        }

        static void Option12()
        {
            ProductOperations.SearchCheapProducts();
        }

        static void Option13()
        {
            StoreOperations.SearchStores();
        }
        static void Option14()
        {
            ManufactureOperations.ListManufactures();
        }
    }
}
