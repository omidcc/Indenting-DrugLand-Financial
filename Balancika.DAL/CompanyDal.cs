using System;
using System.Text;
using System.Data;
using System.Collections;
using Balancika.DAL.Base;

namespace Balancika.DAL
{
	public class CompanyDal : Balancika.DAL.Base.CompanyDalBase
	{
		public CompanyDal() : base()
		{
		}
        public int GetMaximumCompanyID()
        {
            try
            {
                int maxId = GetMaximumID("Company", "CompanyId", 0, "");
                return maxId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
	}
}
