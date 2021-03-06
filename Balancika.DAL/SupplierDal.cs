using System;
using System.Text;
using System.Data;
using System.Collections;
using Balancika.DAL.Base;

namespace Balancika.DAL
{
	public class SupplierDal : Balancika.DAL.Base.SupplierDalBase
	{
		public SupplierDal() : base()
		{
		}
        public int GetMaximumSupplierId()
        {
            try
            {
                int maxId = GetMaximumID("Supplier", "SupplierId", 0, "");
                return maxId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
	}
}
