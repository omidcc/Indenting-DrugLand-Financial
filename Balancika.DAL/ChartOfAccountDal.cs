using System;
using System.Text;
using System.Data;
using System.Collections;
using Balancika.DAL.Base;

namespace Balancika.DAL
{
	public class ChartOfAccountDal : Balancika.DAL.Base.ChartOfAccountDalBase
	{
		public ChartOfAccountDal() : base()
		{
		}

	    public int GetMaxCoaId()
	    {
            try
            {
                int maxId = GetMaximumID("ChartOfAccount", "CoaId", 0, "");
                return maxId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
	    }
	}
}
