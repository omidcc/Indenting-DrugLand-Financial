using System;
using System.Text;
using System.Data;
using System.Collections;
using Balancika.DAL.Base;

namespace Balancika.DAL
{
	public class ListTableDal : Balancika.DAL.Base.ListTableDalBase
	{
		public ListTableDal() : base()
		{
		}

	    public int GetMaxListTableId()
	    {
            try
            {
                int maxId = GetMaximumID("ListTable", "Id", 0, "");
                return maxId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
	    }
	}
}
