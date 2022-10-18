using PharmacySystem.BLL.Interfaces;
using PharmacySystem.DAL.DataAccessLayer.Inplement;
using PharmacySystem.DAL.DataAccessLayer.Interfaces;
using PharmacySystem.DAL.Model;
using System.Collections.Generic;

namespace PharmacySystem.BLL.Implement
{
    public class CustomerBLL : ICustomerBLL
    {
        private ICustomerDAL _customerDAL;

        public CustomerBLL()
        {
            _customerDAL = new CustomerDAL();
        }

        public List<Customer> GetCustomers()
        {
            return _customerDAL.GetCustomers();
        }
    }
}
