using System.Collections.Generic;
using WebStore.DomainModels.Models;

namespace WebStore.Interfaces.Services
{
    /// <summary>
    /// Интерфейс для работы с сотрудниками
    /// </summary>
    public interface IEmployeesData
    {
        /// <summary>
        /// Получение списка сотрудников
        /// </summary>
        /// <returns></returns>
        IEnumerable<Employee> GetAll();
        /// <summary>
        /// Получение сотрудника по id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        Employee GetById(int id);
        /// <summary>
        /// Обновление сотрудника
        /// </summary>
        /// <param name="id">Id сотрудника</param>
        /// <param name="entity">Сотрудник для обновления</param>
        /// <returns></returns>
        Employee UpdateEmployee(int id, Employee entity);
        /// <summary>
        /// Добавить нового
        /// </summary>
        /// <param name="model"></param>
        void AddNew(Employee model);
        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
        void Commit();

    }
}
