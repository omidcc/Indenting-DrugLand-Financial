using System;
using System.Text;
using System.Data;
using System.Collections;
using BALANCIKA.DAL.Base;

namespace BALANCIKA.DAL
{
	public class CostCenterDal : BALANCIKA.DAL.Base.CostCenterDalBase
	{
		public CostCenterDal() : base()
		{
		}

	    public int GetMaxCostCenterId()
	    {
            try
            {
                int maxId = GetMaximumID("CostCenter", "CostCenterId", 0, "");
                return maxId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
	    }
	}
}
