using PeopleApp.ClassLib.Models;
using PeopleApp.Mvc.Helpers;

namespace PeopleApp.Mvc.Services.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<ApiResult<Department>> GetAsync();
        ApiResult<Department> GetById();
        Task<ApiResult<Department>> AddAsync(Department department);
    }
}
