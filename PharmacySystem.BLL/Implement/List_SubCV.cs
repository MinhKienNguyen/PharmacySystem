using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.BLL.Implement
{
    class List_SubCV
    {
        public string PRODUCT_CODE { get; internal set; }
        public string SUB_COVERAGE_CODE { get; internal set; }
        public string DESCRIPTION_VN { get; internal set; }
        public string ORDER_BY { get; internal set; }
        public object REMARK { get; internal set; }
        public string DESCRIPTION_EN { get; internal set; }
        public object IS_FIX { get; internal set; }
    }
}
