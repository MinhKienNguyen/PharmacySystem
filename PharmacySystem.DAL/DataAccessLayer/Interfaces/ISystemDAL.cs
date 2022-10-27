using PharmacySystem.DAL.Model;
using System.Collections.Generic;

namespace PharmacySystem.DAL.DataAccessLayer.Interfaces
{
    public interface ISystemDAL
    {
        List<Unit> GetAllUnit();
    }
}
