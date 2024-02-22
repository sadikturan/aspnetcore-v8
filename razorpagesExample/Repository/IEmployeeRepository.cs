using razorpagesExample.Models;

namespace razorpagesExample.Repository;

public interface IEmployeeRepository
{
    IEnumerable<Employee> GetAll();
}