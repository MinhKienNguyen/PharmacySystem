using PharmacySystem.DAL.Model;
using System.Collections.Generic;

namespace PharmacySystem.BLL.Interfaces
{
    public interface ISystemBLL
    {
        List<Unit> GetAllUnit();
    }
}
