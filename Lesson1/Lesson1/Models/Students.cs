using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson1.Models
{
    public class Students
    {
        public string Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; } = "";
        public string Age { get; set; }
        public string Std { get; set; }
        public string Rpd { get; set; }
        public string Blz { get; set; }

        public static List<Students> LoadFromCsv(string path)
        {
            var strs = File.ReadAllLines(path);
            return (from str in strs
                select str.Split(';')
                into data
                let fio = data[1].Split(' ')
                select new Students
                {
                    Id = data[0],
                    Age = (DateTime.Today.Year - Convert.ToInt32(data[2])).ToString(),
                    LastName = fio[0],
                    FirstName = fio[1],
                    MiddleName = fio.Length == 3 ? fio[2] : "",
                    Std = data[3],
                    Rpd = data[4],
                    Blz = data[5]
                }).ToList();
        }
    }
}
