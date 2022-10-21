using PharmacySystem.DAL.Model;
using PharmacySystem.DAL.Object;
using System.Collections.Generic;

namespace PharmacySystem.BLL.Interfaces
{
    public interface IProductBLL
    {
        List<ProductType> GetProductTypes();
        List<ProductInfor> GetProductByProductType(string productType);
    }
}
