using PharmacySystem.DAL.DataAccessLayer.Interfaces;
using PharmacySystem.DAL.Entity;
using System;

namespace PharmacySystem.DAL.DataAccessLayer.Inplement
{
    public class SequencesDAL: ISequencesDAL
    {
        private readonly DBPharmacyContext _dBPharmacyContext;
        public SequencesDAL()
        {
            _dBPharmacyContext = new DBPharmacyContext();
        }

        public string GetUnitSequenceId()
        {
            try
            {
                var rawQuery = _dBPharmacyContext.Database.SqlQuery<long>("SELECT NEXT VALUE FOR [dbo].[Unit_Sequence];");
                return $"H{rawQuery.SingleAsync().Result.ToString("0000000000000")}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetCustomerSequenceId()
        {
            try
            {
                var rawQuery = _dBPharmacyContext.Database.SqlQuery<long>("SELECT NEXT VALUE FOR [dbo].[Customer_Sequence];");
                return $"C{rawQuery.SingleAsync().Result.ToString("0000000000000")}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetInvoiceNoSequence()
        {
            try
            {
                var rawQuery = _dBPharmacyContext.Database.SqlQuery<long>("SELECT NEXT VALUE FOR [dbo].[InvoiceNo_Sequence];");
                return $"I{rawQuery.SingleAsync().Result.ToString("0000000000000")}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetProductSequence()
        {
            try
            {
                var rawQuery = _dBPharmacyContext.Database.SqlQuery<long>("SELECT NEXT VALUE FOR [dbo].[Product_Sequence];");
                return $"P{rawQuery.SingleAsync().Result.ToString("0000000000000")}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetProductTypeSequence()
        {
            try
            {
                var rawQuery = _dBPharmacyContext.Database.SqlQuery<long>("SELECT NEXT VALUE FOR [dbo].[ProductType_Sequence];");
                return $"PT{rawQuery.SingleAsync().Result.ToString("000000000000")}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
