using PharmacySystem.DAL.DataAccessLayer.Interfaces;
using PharmacySystem.DAL.Entity;
using PharmacySystem.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PharmacySystem.DAL.DataAccessLayer.Inplement
{
    public class CustomerDAL : ICustomerDAL
    {
        private readonly DBPharmacyContext _dBPharmacyContext;
        public CustomerDAL()
        {
            _dBPharmacyContext = new DBPharmacyContext();
        }

        public List<Customer> GetCustomers()
        {
            return _dBPharmacyContext.Customers.ToList();
        }

        public bool InsertCustomer(Customer customer)
        {
            try
            {
                _dBPharmacyContext.Customers.Add(customer);
                _dBPharmacyContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
