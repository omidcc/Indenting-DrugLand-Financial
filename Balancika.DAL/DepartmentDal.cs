using System;
using System.Text;
using System.Data;
using System.Collections;
using Balancika.DAL.Base;

namespace Balancika.DAL
{
	public class DepartmentDal : Balancika.DAL.Base.DepartmentDalBase
	{
		public DepartmentDal() : base()
		{
		}

	    public int GetMaxDeptId()
	    {
            try
            {
                int maxId = GetMaximumID("Department", "DepartmentId", 0, "");
                return maxId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
	    }
	}
}
