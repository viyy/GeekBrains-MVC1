using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using WebStore.DomainModels.Models;
using WebStore.Interfaces.Services;

namespace WebStore.Clients
{
    public class EmployeeClient : Base.BaseClient, IEmployeesData
    {
        public EmployeeClient(IConfiguration configuration) :
            base(configuration)
        {
            ServiceAddress = "api/Employee";
        }
        protected sealed override string ServiceAddress { get; set; }
        public IEnumerable<Employee> GetAll()
        {
            var url = $"{ServiceAddress}";
            var list = Get<List<Employee>>(url);
            return list;
        }
        public Employee GetById(int id)
        {
            var url = $"{ServiceAddress}/{id}";
            var result = Get<Employee>(url);
            return result;
        }
        public Employee UpdateEmployee(int id, Employee entity)
        {
            var url = $"{ServiceAddress}/{id}";
            var response = Put(url, entity);
            var result = response.Content.ReadAsAsync<Employee>().Result;
            return result;
        }
        public void AddNew(Employee model)
        {
            var url = $"{ServiceAddress}";
            Post(url, model);
        }
        public void Delete(int id)
        {
            var url = $"{ServiceAddress}/{id}";
            Delete(url);
        }
        public void Commit()
        {
        }
    }
}