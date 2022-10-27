using PharmacySystem.BLL.Interfaces;
using PharmacySystem.DAL.DataAccessLayer.Inplement;
using PharmacySystem.DAL.DataAccessLayer.Interfaces;
using PharmacySystem.DAL.Model;
using System.Collections.Generic;

namespace PharmacySystem.BLL.Implement
{
    public class SystemBLL : ISystemBLL
    {
        private ISystemDAL _systemDAL;
        public SystemBLL()
        {
            _systemDAL = new SystemDAL();
        }

        public List<Unit> GetAllUnit()
        {
            return _systemDAL.GetAllUnit();
        }
    }
}
