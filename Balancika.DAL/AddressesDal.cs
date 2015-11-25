using System;
using System.Text;
using System.Data;
using System.Collections;
using Balancika.DAL.Base;

namespace Balancika.DAL
{
	public class AddressesDal : Balancika.DAL.Base.AddressesDalBase
	{
		public AddressesDal() : base()
		{
		}
        public int GetMaximumAddressId()
        {
            try
            {
                int maxId = GetMaximumID("Addresses", "AddressId", 0, "");
                return maxId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
	}
}
