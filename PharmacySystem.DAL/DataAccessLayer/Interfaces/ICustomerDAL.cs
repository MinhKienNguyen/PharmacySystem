using PharmacySystem.DAL.Model;
using System.Collections.Generic;

namespace PharmacySystem.DAL.DataAccessLayer.Interfaces
{
    public interface ICustomerDAL
    {
        List<Customer> GetCustomers();
    }
}
