using PharmacySystem.DAL.Model;
using PharmacySystem.DAL.Object;
using System.Collections.Generic;

namespace PharmacySystem.DAL.DataAccessLayer.Interfaces
{
    public interface IProductDAL 
    {
        List<ProductType> GetProductTypes();
        List<ProductInfor> GetProductByProductType(string productType);
    }
}
