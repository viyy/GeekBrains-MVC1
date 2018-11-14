using System;
using System.Collections.Generic;
using System.Linq;
using Lesson2.Infrastructure.Interfaces;
using Lesson2.Models;

namespace Lesson2.Infrastructure.Implementations
{
    public class InMemoryEmployeeData : IEmployeeDataService
    {
        private readonly List<Employee> _data = new List<Employee>
        {
            new Employee {Id=1, FirstName="Camille", LastName="Yeulet", Birth=DateTime.Parse("29/06/1994"), Department="Human Resources"},
            new Employee {Id=2,FirstName="Gaby",LastName="Tipler",Birth=DateTime.Parse("11/12/1995"),Department="Accounting"},
            new Employee {Id=3,FirstName="Naomi",LastName="Fatkin",Birth=DateTime.Parse("25/04/1997"),Department="Services"},
            new Employee {Id=4,FirstName="Merell",LastName="Olivas",Birth=DateTime.Parse("13/06/1995"),Department="Support"},
            new Employee {Id=5,FirstName="Annabelle",LastName="Bleeze",Birth=DateTime.Parse("30/09/1999"),Department="Business Development"},
            new Employee {Id=6,FirstName="Reynolds",LastName="Digges",Birth=DateTime.Parse("31/03/1995"),Department="Engineering"},
            new Employee {Id=7,FirstName="Ronni",LastName="Pendered",Birth=DateTime.Parse("02/02/1995"),Department="Sales"},
            new Employee {Id=8,FirstName="Hoebart",LastName="Nevill",Birth=DateTime.Parse("26/12/1998"),Department="Research and Development"},
            new Employee {Id=9,FirstName="Merrielle",LastName="Hirsthouse",Birth=DateTime.Parse("30/06/2000"),Department="Sales"},
            new Employee {Id=10,FirstName="Winston",LastName="Tomich",Birth=DateTime.Parse("02/11/1998"),Department="Business Development"}
        };

        public IEnumerable<Employee> GetAll()
        {
            return _data;
        }

        public Employee GetById(int id)
        {
            return _data.FirstOrDefault(i => i.Id == id);
        }

        public void AddNew(Employee model)
        {
                var nid = _data.Max(i=>i.Id) + 1;
                model.Id = nid;
                _data.Add(model);
        }

        public void Commit()
        {
            
        }

        public void Delete(int id)
        {
            var t = GetById(id);
            if (t == null) return;
            _data.Remove(t);
        }
    }
}