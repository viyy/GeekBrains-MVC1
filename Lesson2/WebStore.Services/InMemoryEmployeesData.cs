using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.DomainModels.Models;
using WebStore.Interfaces.Services;

namespace WebStore.Services
{
    public class InMemoryEmployeesData : IEmployeesData
    {
        private readonly List<Employee> _employees;

        public InMemoryEmployeesData()
        {
            _employees = new List<Employee>(3)
            {
                new Employee(){Id = 1, FirstName = "Вася", SurName = "Пупкин", Patronymic = "Иванович", Age = 22, Position = "Директор"},
                new Employee(){Id = 2, FirstName = "Иван", SurName = "Холявко", Patronymic = "Александрович", Age = 30, Position = "Программист"},
                new Employee(){Id = 3, FirstName = "Роберт", SurName = "Серов", Patronymic = "Сигизмундович", Age = 50, Position = "Зав. склада"}
            };
        }
        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }

        public Employee GetById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id.Equals(id));
        }

        public Employee UpdateEmployee(int id, Employee entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var employee = _employees.FirstOrDefault(e => e.Id.Equals(id));
            if (employee == null)
                throw new InvalidOperationException("Employee not exits");

            employee.Age = entity.Age;
            employee.FirstName = entity.FirstName;
            employee.Patronymic = entity.Patronymic;
            employee.SurName = entity.SurName;
            employee.Position = entity.Position;

            return employee;
        }

        public void Commit()
        {
            //ничего не делаем
        }

        public void AddNew(Employee model)
        {
            model.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(model);
        }

        public void Delete(int id)
        {
            var employee = GetById(id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
        }
    }
}
