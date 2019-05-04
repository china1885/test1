using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ZtpBoss.Model;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace ZtpBoss.DAL
{
    public class CommonValuesDAL
    {
        public static List<Model.CommonValues> GetAppID_Secret()
        {
            string cmdText = "select * from db1.CommonValues where key_str='AppSecret' or key_str='AppID'";
            DataTable dt = MySqlHelper.GetDataSet(System.Data.CommandType.Text, cmdText).Tables[0];
            List<Model.CommonValues> result = null;
            if (dt.Rows.Count > 0)
            {
                result = new List<Model.CommonValues>();
                Model.CommonValues cv = null;
                foreach (DataRow dr in dt.Rows)
                {
                    cv = new Model.CommonValues();
                    LoadEntity(dr, cv);
                    result.Add(cv);
                }
            }
            return result;

        }

        public static int UpdateToken(Model.CommonValues cv)
        {
            string cmdText = "update db1.CommonValues set value_Str=@value_Str,update_time=@update_time where key_Str=@key_Str";

            MySqlParameter[] myParams =
            {
                new MySqlParameter("@value_Str",MySqlDbType.VarChar),
                new MySqlParameter("@update_time",MySqlDbType.DateTime),
                new MySqlParameter("@key_Str",MySqlDbType.VarChar)
            };
            myParams[0].Value = cv.Value_Str;
            myParams[1].Value = cv.Update_time;
            myParams[2].Value = cv.Key_Str;

            return MySqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, myParams);
        }

        private static void LoadEntity(DataRow dr, CommonValues cv)
        {
            cv.Sqc = Convert.ToInt32(dr["sqc"]);
            cv.Key_Str = dr["key_Str"] != DBNull.Value ? dr["key_Str"].ToString() : String.Empty;
            cv.Value_Str = dr["value_Str"] != DBNull.Value ? dr["value_Str"].ToString() : String.Empty;
            cv.Create_time = dr["create_time"] != DBNull.Value ? Convert.ToDateTime(dr["Create_time"]) : DateTime.MinValue;
            cv.Update_time = dr["update_time"] != DBNull.Value ? Convert.ToDateTime(dr["update_time"]) : DateTime.MinValue;
        }
    }
}
