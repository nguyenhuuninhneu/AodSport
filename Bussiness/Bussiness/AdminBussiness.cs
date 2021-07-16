using DAL;
using SqlDataProvider.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace Bussiness
{
	public class AdminBussiness : BaseBussiness
	{
		public Admin[] GetAll()
		{
			List<Admin> list = new List<Admin>();
			SqlDataReader sqlDataReader = null;
			try
			{
				this.db.GetReader(ref sqlDataReader, "SP_Active_All");
				while (sqlDataReader.Read())
				{
					list.Add(this.ReaderToModel(sqlDataReader));
				}
			}
			catch (Exception exception)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", exception);
				}
			}
			finally
			{
				if (sqlDataReader != null && !sqlDataReader.IsClosed)
				{
					sqlDataReader.Close();
				}
			}
			return list.ToArray();
		}
        public Admin[] GetByPage(int page, int size, ref int total, int order, string name, int consortiaID, int level, int openApply)
        {
            List<Admin> models = new List<Admin>();
            try
            {
                string sWhere = " IsExist=1 ";
                if (!string.IsNullOrEmpty(name))
                {
                    sWhere = sWhere + " and ConsortiaName like '%" + name + "%' ";
                }
                if (consortiaID != -1)
                {
                    object obj = sWhere;
                    sWhere = string.Concat(new object[]
                    {
                        obj,
                        " and ConsortiaID =",
                        consortiaID,
                        " "
                    });
                }
                if (level != -1)
                {
                    object obj2 = sWhere;
                    sWhere = string.Concat(new object[]
                    {
                        obj2,
                        " and Level =",
                        level,
                        " "
                    });
                }
                if (openApply != -1)
                {
                    object obj3 = sWhere;
                    sWhere = string.Concat(new object[]
                    {
                        obj3,
                        " and OpenApply =",
                        openApply,
                        " "
                    });
                }
                string sOrder = "ConsortiaName";
                switch (order)
                {
                    case 1:
                        sOrder = "ReputeSort";
                        break;

                    case 2:
                        sOrder = "ChairmanName";
                        break;

                    case 3:
                        sOrder = "Count desc";
                        break;

                    case 4:
                        sOrder = "Level desc";
                        break;

                    case 5:
                        sOrder = "Honor desc";
                        break;

                    case 10:
                        sOrder = "LastDayRiches desc";
                        break;

                    case 11:
                        sOrder = "AddDayRiches desc";
                        break;

                    case 12:
                        sOrder = "AddWeekRiches desc";
                        break;

                    case 13:
                        sOrder = "LastDayHonor desc";
                        break;

                    case 14:
                        sOrder = "AddDayHonor desc";
                        break;

                    case 15:
                        sOrder = "AddWeekHonor desc";
                        break;

                    case 16:
                        sOrder = "level desc,LastDayRiches desc";
                        break;
                }
                sOrder += ",ConsortiaID ";
                DataTable dt = base.GetPage("V_Consortia", sWhere, page, size, "*", sOrder, "ConsortiaID", ref total);
                foreach (DataRow dr in dt.Rows)
                {
                    models.Add(new Admin
                    {
                        Id = (int)dr["Id"],
                        UserName = dr["UserName"].ToString(),
                        Password = dr["Password"].ToString(),
                        FirstName = dr["FirstName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        Email = dr["Email"].ToString(),
                        Phone = dr["Phone"].ToString(),
                        Facebook = dr["Facebook"].ToString(),
                        CreatedDate = (DateTime)dr["CreatedDate"],
                        ModifiedDate = (DateTime)dr["ModifiedDate"],
                        CreateById = (int)dr["CreateById"],
                        ModifiedId = (int)dr["ModifiedId"],
                        IsActive = (bool)dr["IsActive"]
                    });
                }
            }
            catch (Exception e)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                {
                    BaseBussiness.log.Error("Init", e);
                }
            }
            return models.ToArray();
        }
        public Admin GetById(int id)
		{
			SqlDataReader sqlDataReader = null;
			try
			{
				SqlParameter[] array = new SqlParameter[]
				{
					new SqlParameter("@ID", SqlDbType.Int, 4)
				};
				array[0].Value = id;
				this.db.GetReader(ref sqlDataReader, "SP_Active_Single", array);
				if (sqlDataReader.Read())
				{
					return this.ReaderToModel(sqlDataReader);
				}
			}
			catch (Exception exception)
			{
				if (BaseBussiness.log.IsErrorEnabled)
				{
					BaseBussiness.log.Error("Init", exception);
				}
			}
			finally
			{
				if (sqlDataReader != null && !sqlDataReader.IsClosed)
				{
					sqlDataReader.Close();
				}
			}
			return null;
		}
        public bool Add(Admin model, ref string msg)
        {
            bool result = false;
            try
            {
                SqlParameter[] para = new SqlParameter[13];
                para[0] = new SqlParameter("@Id", model.Id);
                para[0].Direction = ParameterDirection.InputOutput;
                para[1] = new SqlParameter("@UserName", model.UserName);
                para[2] = new SqlParameter("@Password", model.Password);
                para[3] = new SqlParameter("@FirstName", model.FirstName);
                para[4] = new SqlParameter("@LastName", (model.LastName == null) ? "" : model.LastName);
                para[5] = new SqlParameter("@Email", (model.Email == null) ? "" : model.Email);
                para[6] = new SqlParameter("@Phone", model.Phone);
                para[7] = new SqlParameter("@Facebook", (model.Facebook == null) ? "" : model.Facebook);
                para[8] = new SqlParameter("@CreatedDate", model.CreatedDate);
                para[9] = new SqlParameter("@ModifiedDate", model.ModifiedDate);
                para[10] = new SqlParameter("@CreateById", model.CreateById);
                para[11] = new SqlParameter("@ModifiedId", model.ModifiedId);
                para[12] = new SqlParameter("@IsActive", model.IsActive);
                para[13] = new SqlParameter("@Result", SqlDbType.Int);
                para[13].Direction = ParameterDirection.ReturnValue;
                result = this.db.RunProcedure("SP_Consortia_Add", para);
                int returnValue = (int)para[19].Value;
                result = (returnValue == 0);
                if (result)
                {
                    model.Id = (int)para[0].Value;
                }
            }
            catch (Exception e)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                {
                    BaseBussiness.log.Error("Init", e);
                }
            }
            return result;
        }
        public bool Update(Admin model, ref string msg)
        {
            bool result = false;
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@Id", model.Id),
                    new SqlParameter("@UserName", model.UserName),
                    new SqlParameter("@Password", model.Password),
                    new SqlParameter("@FirstName", model.FirstName),
                    new SqlParameter("@LastName", model.LastName),
                    new SqlParameter("@Email", model.Email),
                    new SqlParameter("@Phone", model.Phone),
                    new SqlParameter("@Facebook", model.Facebook),
                    new SqlParameter("@CreatedDate", model.CreatedDate),
                    new SqlParameter("@ModifiedDate", model.ModifiedDate),
                    new SqlParameter("@CreateById", model.CreateById),
                    new SqlParameter("@ModifiedId", model.ModifiedId),
                    new SqlParameter("@IsActive", model.IsActive),
                    new SqlParameter("@Result", SqlDbType.Int)
                };
                para[5].Direction = ParameterDirection.ReturnValue;
                result = this.db.RunProcedure("SP_ConsortiaBadge_Update", para);
                int returnValue = (int)para[5].Value;
                result = (returnValue == 0);
                int num = returnValue;
                if (num == 2)
                {
                    msg = "ConsortiaBussiness.BuyBadge.Msg2";
                }
            }
            catch (Exception e)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                {
                    BaseBussiness.log.Error("Init", e);
                }
            }
            return result;
        }
        public bool Delete(int id)
        {
            bool result = false;
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@Id", id)
                };
                result = this.db.RunProcedure("SP_Users_Friends_Delete", para);
            }
            catch (Exception e)
            {
                if (BaseBussiness.log.IsErrorEnabled)
                {
                    BaseBussiness.log.Error("Init", e);
                }
            }
            return result;
        }
       
        public Admin ReaderToModel(SqlDataReader reader)
		{
			Admin model = new Admin();
			model.Id = (int)reader["Id"];
			model.UserName = ((reader["UserName"] == null) ? "" : reader["UserName"].ToString());
			model.Password = ((reader["Password"] == null) ? "" : reader["Password"].ToString());
			model.FirstName = ((reader["FirstName"] == null) ? "" : reader["FirstName"].ToString());
			model.LastName = ((reader["LastName"] == null) ? "" : reader["LastName"].ToString());
			model.Email = ((reader["Email"] == null) ? "" : reader["Email"].ToString());
			model.Phone = ((reader["Phone"] == null) ? "" : reader["Phone"].ToString());
			model.Facebook = ((reader["Facebook"] == null) ? "" : reader["Facebook"].ToString());
			model.CreatedDate = string.IsNullOrEmpty(reader["CreatedDate"].ToString()) ? DateTime.Now
					 : (DateTime)reader["CreatedDate"];
			model.ModifiedDate = string.IsNullOrEmpty(reader["ModifiedDate"].ToString()) ? DateTime.Now
					 : (DateTime)reader["ModifiedDate"];

			model.CreateById = reader["CreateById"] == null ? 0 :  (int)reader["CreateById"];
			model.ModifiedId = reader["ModifiedId"] == null ? 0 : (int)reader["ModifiedId"];
			model.IsActive = (bool)reader["IsActive"];
			return model;
		}
	}
}
