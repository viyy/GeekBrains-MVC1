using System;
using System.Collections.Generic;
using System.IO;

namespace WebStore.Models
{
    public class Account
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal TotalSpent { get; set; }
        public DateTime Registered { get; set; }
        public DateTime LastPurchase { get; set; }
        public decimal LastPurchaseCost { get; set; }

        public static List<Account> GenerateTestData(int count = 5)
        {
            var res = new List<Account>();
            var rnd = new Random();
            for (var i = 0; i < count; i++) { 

                var reg = rnd.Next(30, 365);
                res.Add(new Account
                {
                    Id = i.ToString(),
                    Name = GetRandomString(),
                    TotalSpent = rnd.Next(10000,100000),
                    Registered = DateTime.Now.AddDays(-reg),
                    LastPurchase = DateTime.Now.AddDays(-rnd.Next(1, reg)),
                    LastPurchaseCost = rnd.Next(1000, 2000)
                });
            }
            return res;
        }

        private static string GetRandomString()
        {
            var path = Path.GetRandomFileName();
            path = path.Replace(".", ""); // Remove period.
            return path;
        }
    }
}