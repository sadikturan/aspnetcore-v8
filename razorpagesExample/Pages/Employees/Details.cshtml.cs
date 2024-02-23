using Microsoft.AspNetCore.Mvc.RazorPages;
using razorpagesExample.Models;
using razorpagesExample.Repository;

namespace razorpagesExample.Pages.Employees;

public class DetailsModel: PageModel
{
    private readonly IEmployeeRepository _employeeRepository;
    public DetailsModel(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    public Employee Employee { get; set; } = default!;
    public void OnGet(int id)
    {
        Employee = _employeeRepository.GetById(id);
    }

}