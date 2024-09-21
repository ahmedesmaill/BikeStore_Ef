using Demo2.Data;
using Demo2.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;

namespace Demo2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ApplicationDbContext Context = new ApplicationDbContext();

            //var result = Context.Customers.Where(e => e.State=="NY").Select(e=> new {e.FirstName , e.LastName ,e.Phone,e.State});
            //foreach (var item in result)
            //{
            //    Console.WriteLine($"name : {item.FirstName} Phone: {item.Phone} State: {item.State}");
                
            //}



            // Retrieve all categories from the production.categories table.
            var Categories = Context.Categories.ToList();  
            foreach (var item in Categories)
            {
                Console.WriteLine($"Id : {item.CategoryId} Name : {item.CategoryName}");
            }

            Console.WriteLine("==========================================================================");

            // Retrieve the first product from the production.products table.
            var result = Context.Products.FirstOrDefault();
            
            Console.WriteLine($"Id : {result.ProductId} Name : {result.ProductName}");

            Console.WriteLine("==========================================================================");
            Console.WriteLine("==========================================================================");

            //Retrieve a specific product from the production.products table by ID.
            var result1 = Context.Products.FirstOrDefault(e => e.ProductId == 5);
            Console.WriteLine($"Id : {result1.ProductId} Name : {result1.ProductName}");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("==========================================================================");

            // Retrieve all products from the production.products table with a certain model year(2017).


            var result2 = Context.Products.Where(e => e.ModelYear == 2017).ToList();
            foreach (var item in result2)
            {
                Console.WriteLine($"Id : {item.ProductId} Name : {item.ProductName}");
            }

            Console.WriteLine("==========================================================================");
            Console.WriteLine("==========================================================================");

            //  Retrieve a specific customer from the sales.customers table by ID.

            var Customer2 = Context.Customers.FirstOrDefault(e => e.CustomerId == 2);
            Console.WriteLine($"Id : {Customer2.CustomerId} Name : {Customer2.FirstName} ");


            Console.WriteLine("==========================================================================");
            Console.WriteLine("==========================================================================");

            //Retrieve a list of product names and their corresponding brand names.

            var result3 = Context.Products.Select(e => new { e.ProductName, e.Brand.BrandName }).ToList();

            foreach (var item in result3)
            {
                Console.WriteLine($"ProductName : {item.ProductName} BrandName : {item.BrandName}");
            }
            Console.WriteLine("==========================================================================");
            Console.WriteLine("==========================================================================");


            //Count the number of products in a specific category (2).

            var Count = Context.Products.Count(e => e.CategoryId == 2);

            Console.WriteLine(Count);

            Console.WriteLine("==========================================================================");
            Console.WriteLine("==========================================================================");

            //Calculate the total list price of all products in a specific category.

            var total = Context.Products.Where(e => e.CategoryId == 2).Sum(e => e.ListPrice);

            Console.WriteLine(total);

            Console.WriteLine("==========================================================================");
            Console.WriteLine("==========================================================================");


            //Calculate the average list price of products.
            var avg = Context.Products.Average(e=>e.ListPrice);
            Console.WriteLine(avg);

            Console.WriteLine("==========================================================================");
            Console.WriteLine("==========================================================================");


            //Retrieve orders that are completed.

            var completed = Context.Orders.Where(e=>e.OrderStatus == 4).ToList();

            foreach (var item in completed)
            {
                Console.WriteLine($"ID : {item.OrderId} Date : {item.OrderDate}");
            }

           












        }
    }
}
