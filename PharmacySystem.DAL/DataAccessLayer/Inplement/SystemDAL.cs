using PharmacySystem.DAL.DataAccessLayer.Interfaces;
using PharmacySystem.DAL.Entity;
using PharmacySystem.DAL.Model;
using System.Collections.Generic;
using System.Linq;

namespace PharmacySystem.DAL.DataAccessLayer.Inplement
{
    public class SystemDAL: ISystemDAL
    {
        private readonly DBPharmacyContext _dBPharmacyContext;
        public SystemDAL()
        {
            _dBPharmacyContext = new DBPharmacyContext();
        }

        public List<Unit> GetAllUnit()
        {
            return _dBPharmacyContext.Units.ToList();
        }    
    }
}
