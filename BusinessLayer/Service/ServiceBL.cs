using BusinessLayer.Interface;
using CommonLayer.Request;
using CommonLayer.Responce;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class ServiceBL : IServiceBL
    {
        private readonly IServiceRL _serviceRL;

        public ServiceBL(IServiceRL serviceRL)
        {
            _serviceRL = serviceRL;
        }
        public async Task<List<EmployeeResponce>> EmployeeRegistration(EmployeeDetails data){

            List<EmployeeResponce> employee = new List<EmployeeResponce>();
            return employee;

        }
    }
}
