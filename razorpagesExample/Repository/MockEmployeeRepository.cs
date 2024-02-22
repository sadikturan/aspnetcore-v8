using razorpagesExample.Models;

namespace razorpagesExample.Repository;

public class MockEmployeeRepository : IEmployeeRepository
{
    private List<Employee> _employeeList;
    public MockEmployeeRepository()
    {
        _employeeList = new List<Employee>()
        {
            new Employee { Id = 1, Name="Ahmet Yılmaz", Email = "ahmetyilmaz@gmailc.com", Photo = "1.jpg", Deparment = "Muhasebe"},
            new Employee { Id = 1, Name="Hasan Cengiz", Email = "hasancengiz@gmailc.com", Photo = "2.jpg", Deparment = "Muhasebe"},
            new Employee { Id = 1, Name="Canan Turan", Email = "cananturan@gmailc.com", Photo = "3.jpg", Deparment = "Muhasebe"},
            new Employee { Id = 1, Name="Volkan Yükselen", Email = "volkanyukselen@gmailc.com", Photo = "4.jpg", Deparment = "Muhasebe"},
            new Employee { Id = 1, Name="Volkan Yükselen", Email = "volkanyukselen@gmailc.com", Photo = "4.jpg", Deparment = "Muhasebe"},
            new Employee { Id = 1, Name="Volkan Yükselen", Email = "volkanyukselen@gmailc.com", Photo = "4.jpg", Deparment = "Muhasebe"},
        };
    }
    public IEnumerable<Employee> GetAll()
    {
        return _employeeList;
    }
}


