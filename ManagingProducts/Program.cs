using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using ManagingProducts.Models;
using ManagingProducts.Repositories;
using ManagingProducts.Operations;

namespace ManagingProducts
{
    class Program
    {
        static void Main(string[] args)
        {

            Menu.ConsoleMenu();
            Menu.Run();

        }
    }
}
