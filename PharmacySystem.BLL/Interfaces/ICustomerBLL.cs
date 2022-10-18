using PharmacySystem.DAL.Model;
using System.Collections.Generic;

namespace PharmacySystem.BLL.Interfaces
{
    public interface ICustomerBLL
    {
        List<Customer> GetCustomers();
    }
}
