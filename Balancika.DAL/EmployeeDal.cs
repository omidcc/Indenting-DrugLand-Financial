using System;
using System.Text;
using System.Data;
using System.Collections;
using Balancika.DAL.Base;

namespace Balancika.DAL
{
	public class EmployeeDal : Balancika.DAL.Base.EmployeeDalBase
	{
		public EmployeeDal() : base()
		{
		}
        public int GetMaximumEmployeeId()
        {
            try
            {
                int maxId = GetMaximumID("Employee", "EmployeeId", 0, "");
                return maxId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
	}
}
