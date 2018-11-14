using System.Collections.Generic;
using Lesson2.Models;

namespace Lesson2.Infrastructure.Interfaces
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