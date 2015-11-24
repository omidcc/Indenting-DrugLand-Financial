using System;
using System.Text;
using System.Data;
using System.Collections;
using Balancika.DAL.Base;

namespace Balancika.DAL
{
	public class DesignationDal : Balancika.DAL.Base.DesignationDalBase
	{
		public DesignationDal() : base()
		{
		}
        public int GetMaximumDesignationId()
        {
            try
            {
                int maxId = GetMaximumID("Designation", "DesignationId", 0, "");
                return maxId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
	}
}
