using System;
using System.Text;
using System.Data;
using System.Collections;
using Balancika.DAL.Base;

namespace Balancika.DAL
{
	public class ChartOfAccountGroupDal : Balancika.DAL.Base.ChartOfAccountGroupDalBase
	{
		public ChartOfAccountGroupDal() : base()
		{
		}

	    public int GetMaxCoaGroupId()
	    {
            try
            {
                int maxId = GetMaximumID("ChartOfAccountGroup", "CoaGroupId", 0, "");
                return maxId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
	    }
	}
}
