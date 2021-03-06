using System;
using System.Text;
using System.Data;
using System.Collections;
using Balancika.DAL.Base;

namespace Balancika.DAL
{
	public class CustomerDal : Balancika.DAL.Base.CustomerDalBase
	{
		public CustomerDal() : base()
		{
		}
        public int GetMaximumCustomerId()
        {
            try
            {
                int maxId = GetMaximumID("Customer", "CustomerId", 0, "");
                return maxId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
	}
}
