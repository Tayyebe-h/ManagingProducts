using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ManagingProducts.Models;
using ManagingProducts.Operations;
using ManagingProducts.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace ManagingProducts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Menu.ConsoleMenu();
            Menu.Run();
        }
    }
}
