using CommonLayer.Request;
using CommonLayer.Responce;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IServiceBL
    {
        Task<List<EmployeeResponce>> EmployeeRegistration(EmployeeDetails data);
    }
}
