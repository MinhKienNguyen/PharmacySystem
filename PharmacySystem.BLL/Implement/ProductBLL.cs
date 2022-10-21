using PharmacySystem.BLL.Interfaces;
using PharmacySystem.DAL.DataAccessLayer.Inplement;
using PharmacySystem.DAL.DataAccessLayer.Interfaces;
using PharmacySystem.DAL.Model;
using PharmacySystem.DAL.Object;
using System.Collections.Generic;

namespace PharmacySystem.BLL.Implement
{
    public class ProductBLL : IProductBLL
    {
        private IProductDAL _productDAL;
        public ProductBLL()
        {
            _productDAL = new ProductDAL();
        }

        public List<ProductType> GetProductTypes()
        {
            return _productDAL.GetProductTypes();
        }

        public List<ProductInfor> GetProductByProductType(string productType)
        {
            return _productDAL.GetProductByProductType(productType);
        }
    }
}
