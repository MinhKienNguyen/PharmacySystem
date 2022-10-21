using PharmacySystem.DAL.DataAccessLayer.Interfaces;
using PharmacySystem.DAL.Entity;
using PharmacySystem.DAL.Model;
using PharmacySystem.DAL.Object;
using System.Collections.Generic;
using System.Linq;

namespace PharmacySystem.DAL.DataAccessLayer.Inplement
{
    public class ProductDAL: IProductDAL
    {
        private readonly DBPharmacyContext _dBPharmacyContext;
        public ProductDAL()
        {
            _dBPharmacyContext = new DBPharmacyContext();
        }

        public List<ProductType> GetProductTypes()
        {
            return _dBPharmacyContext.ProductTypes.ToList();
        }

        public List<ProductInfor> GetProductByProductType(string productType)
        {
            var result = (from product in _dBPharmacyContext.Products
                         join unit in _dBPharmacyContext.Units on product.UnitId equals unit.UnitId
                         join prodType in _dBPharmacyContext.ProductTypes on product.ProductTypeId equals prodType.ProductTypeId
                         where product.ProductTypeId == productType.Trim()
                         select new ProductInfor
                         {
                             ProductTypeId = product.ProductTypeId,
                             ProductTypeName = prodType.ProductTypeName,
                             ProductId = product.ProductId,
                             ProductName = product.ProductName,
                             UnitId = unit.UnitId,
                             UnitName = unit.UnitName,
                             Quantity = product.Quantity,
                             Pharmaceutical = product.Pharmaceutical,
                             Concentrations = product.Concentrations,
                             CountryManufacture = product.CountryManufacture,
                             EntryPrice = product.EntryPrice,
                             ExportPrice = product.ExportPrice,
                             Manufacturer = product.Manufacturer,
                             Remark = product.Remark
                         }).ToList();
            return result;
        }
    }
}
