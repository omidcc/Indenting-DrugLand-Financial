using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Balancika.BLL.Base;

namespace Balancika.BLL
{
	public class UserRoleMapping : Balancika.BLL.Base.UserRoleMappingBase
	{
		private static Balancika.DAL.UserRoleMappingDal Dal = new Balancika.DAL.UserRoleMappingDal();
		public UserRoleMapping() : base()
		{
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Int32 DeleteUserRoleMappingByUserId(Int32 userId)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@UserId", userId);

            return dal.DeleteUserRoleMappingByUserId(lstItems);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_userId"></param>
        /// <param name="_companyId"></param>
        /// <returns></returns>
        public UserRoleMapping GetUserRoleMappingByUserId(int _userId)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@UserId", _userId);

            try
            {
                DataTable dt = dal.GetUserRoleMappingByUserId(lstItems);

                if (dt.Rows.Count > 0)
                {
                    return GetObject(dt.Rows[0]);
                }
                else
                    return new UserRoleMapping();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public List<UserRoleMapping> GetAllUserRoleMappingbyUserId(int _userId, int CompanyId)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@UserId", _userId);
            lstItems.Add("@CompanyId", CompanyId);
            DataTable dt = dal.GetUserRoleMappingByUserId(lstItems);
            List<UserRoleMapping> UserRoleMappingList = new List<UserRoleMapping>();
            foreach (DataRow dr in dt.Rows)
            {
                UserRoleMappingList.Add(GetObject(dr));
            }
            return UserRoleMappingList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_userId"></param>
        /// <param name="_companyId"></param>
        /// <returns></returns>
        public int GetRoleIdForUser(int _userId)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@UserId", _userId);

            try
            {
                string strRoleId = dal.GetRoleIdForUser(lstItems);

                if (strRoleId != null && strRoleId != string.Empty)
                    return int.Parse(strRoleId);
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
	}
}
