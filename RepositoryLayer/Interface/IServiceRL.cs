using CommonLayer.Request;
using CommonLayer.Responce;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IServiceRL
    {
        Task<List<EmployeeResponce>> EmployeeDetails();

        Task<List<EmployeeResponce>> AddEmployeeDetails(EmployeeDetails details);

        Task<List<EmployeeResponce>> UpdateEmployeeDetails(EmployeeDetails details, int EmployeeId);
    }
}
