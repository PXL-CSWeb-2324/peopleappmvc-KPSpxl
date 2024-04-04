using Microsoft.AspNetCore.Mvc;
using PeopleApp.ClassLib.Models;
using PeopleApp.Mvc.Services.Interfaces;

namespace PeopleApp.Mvc.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentRepository _repo;
        public DepartmentController(IDepartmentRepository repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var result = await _repo.GetAsync();
            if(result.Succeeded) 
            {
                return View(result.Entities);
            }
            return View(Enumerable.Empty<Department>());
        }
    }
}
