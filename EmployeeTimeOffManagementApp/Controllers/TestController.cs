using EmployeeTimeOffManagementApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTimeOffManagementApp.Controllers;

public class TestController : Controller
{
    // GET
    public IActionResult Index()
    {
        var data = new TestViewModel
        {
            Name = "John Doe",
        };
        return View(data);
    }
}