using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.BLL.Implement
{
    class Class1
    {
        public List<LstBenefitPerson> GetBenefitData(RISKS risk)
        {
            List<LstBenefitPerson> lst_BenefitPerson = new List<LstBenefitPerson>();
            var lst_bf = new List<datatb_Benefits>();
            var lst_subCV = new List<List_SubCV>();
            foreach (var item in risk.RISK)
            {
                foreach (var cv in item.COVERAGES.COVERAGE)
                {
                    foreach (var sub in cv.SUBCOVERAGES.SUBCOVERAGE)
                    {
                        foreach (var tem in lst_subCV)
                        {
                            var code = tem.PRODUCT_CODE + "_" + tem.SUB_COVERAGE_CODE;
                            if (sub.SubCoverageCode == code)
                            {
                                var bf = new datatb_Benefits();
                                bf.PlanName = item.PlanName;
                                bf.CoverageName = tem.ORDER_BY + ". " + tem.DESCRIPTION_EN + "/" + tem.DESCRIPTION_VN;
                                bf.Coverage_FinalPremium = sub.SubCoverageLimit;
                                bf.OrderBy = tem.ORDER_BY.ToString();
                                bf.REMARK = tem.REMARK;
                                bf.IS_FIX = tem.IS_FIX;
                                lst_bf.Add(bf);
                            }
                            else if (cv.CoverageCode == code)
                            {
                                var bf = new datatb_Benefits();
                                bf.PlanName = item.PlanName;
                                bf.CoverageName = tem.ORDER_BY + ". " + tem.DESCRIPTION_EN + "/" + tem.DESCRIPTION_VN;
                                bf.Coverage_FinalPremium = sub.SubCoverageLimit;
                                bf.OrderBy = tem.ORDER_BY.ToString();
                                bf.REMARK = tem.REMARK;
                                bf.IS_FIX = tem.IS_FIX;
                                lst_bf.Add(bf);
                            }
                        }
                    }
                }
            }
            var lst_bf1 = (from subTem in risk.RISK
                          let COVERAGES = subTem.COVERAGES.COVERAGE
                          from cov in COVERAGES
                          let SUBCOVERAGES = cov.SUBCOVERAGES.SUBCOVERAGE
                          from subCove in SUBCOVERAGES
                          join tem in lst_subCV on cov.CoverageCode  equals (tem.PRODUCT_CODE + "_" + tem.SUB_COVERAGE_CODE)
                          select new datatb_Benefits
                          {
                              PlanName = subTem.PlanName,
                              CoverageName = tem.ORDER_BY + ". " + tem.DESCRIPTION_EN + "/" + tem.DESCRIPTION_VN,
                              Coverage_FinalPremium = subCove.SubCoverageLimit,
                              OrderBy = tem.ORDER_BY.ToString(),
                              REMARK = tem.REMARK,
                              IS_FIX = tem.IS_FIX
                          }).ToList();
            //216 giăc
            //117 khẩu trang

            //75 dép

            var lst_bf2 = (from subTem in risk.RISK
                          let COVERAGES = subTem.COVERAGES.COVERAGE
                          from cov in COVERAGES
                          let SUBCOVERAGES = cov.SUBCOVERAGES.SUBCOVERAGE
                          from subCove in SUBCOVERAGES
                          join tem in lst_subCV on subCove.SubCoverageCode equals (tem.PRODUCT_CODE + "_" + tem.SUB_COVERAGE_CODE)
                          select new datatb_Benefits
                          {
                              PlanName = subTem.PlanName,
                              CoverageName = tem.ORDER_BY + ". " + tem.DESCRIPTION_EN + "/" + tem.DESCRIPTION_VN,
                              Coverage_FinalPremium = subCove.SubCoverageLimit,
                              OrderBy = tem.ORDER_BY.ToString(),
                              REMARK = tem.REMARK,
                              IS_FIX = tem.IS_FIX
                          }).ToList();
            lst_bf1.AddRange(lst_bf2);
            var lst_grb = lst_bf
                        .OrderBy(x => x.OrderBy)
                        .GroupBy(x => x.CoverageName)
                        .Select(grp => new
                        {
                            CoverageName = grp.Key,
                            SumInsured = grp.Max(x => x.Coverage_FinalPremium),
                            REMARK = grp.Max(x => x.REMARK),
                            IS_FIX = grp.Max(x => x.IS_FIX),
                        }).ToList();
            int i = lst_grb.Count;
            int count = 0;
            if (i % 2 == 0)
                count = Convert.ToInt32(i / 2);
            else
                count = Convert.ToInt32(i / 2) + 1;
            var t = lst_grb.Skip(0).Take(count).ToList();
            var t1 = lst_grb.Skip(count).Take(i % 2 == 0 ? count : count - 1).ToList();
            int C = 0;
            foreach (var u in t)
            {
                if (u.IS_FIX == true)
                {
                    var l = new LstBenefitPerson();
                    l.Benefit = u.CoverageName;
                    l.SumInsured = u.REMARK;
                    l.Prio = C++;
                    lst_BenefitPerson.Add(l);
                }
                else
                {
                    var l = new LstBenefitPerson();
                    l.Benefit = u.CoverageName;
                    l.SumInsured = u.SumInsured.convertDecimalToString2();
                    l.Prio = C++;
                    lst_BenefitPerson.Add(l);
                }
            }
            int h = 0;
            foreach (var u in t1)
            {
                if (u.IS_FIX == true)
                {
                    var o = lst_BenefitPerson.ElementAt(h);
                    o.Benefit1 = u.CoverageName;
                    o.SumInsured1 = u.REMARK;
                    h++;
                }
                else
                {
                    var o = lst_BenefitPerson.ElementAt(h);
                    o.Benefit1 = u.CoverageName;
                    o.SumInsured1 = u.SumInsured.convertDecimalToString2();
                    h++;
                }
            }
            return lst_BenefitPerson;
        }
    }
}
