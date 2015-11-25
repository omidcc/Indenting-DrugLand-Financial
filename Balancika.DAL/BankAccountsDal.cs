using System;
using System.Text;
using System.Data;
using System.Collections;
using Balancika.DAL.Base;

namespace Balancika.DAL
{
	public class BankAccountsDal : Balancika.DAL.Base.BankAccountsDalBase
	{
		public BankAccountsDal() : base()
		{
		}

	    public int GetMaxAccountId()
	    {
            try
            {
                int maxId = GetMaximumID("BankAccounts", "BankAccountId", 0, "");
                return maxId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
	    }
	}
}
