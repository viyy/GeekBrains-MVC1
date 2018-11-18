using System.Collections.Generic;
using WebStore.Models;

namespace WebStore.Infrastructure.Interfaces
{
    public interface IEmployeeDataService
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        void AddNew(Employee model);
        void Commit();
        void Delete(int id);

    }
}