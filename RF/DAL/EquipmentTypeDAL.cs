using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Utils;

namespace DAL
{
    public class EquipmentTypeDAL
    {
        public static List<EquipmentTypeModel> GetEquipmentAgreementList()
        {
            var connectionString = ConfigurationManager.AppSettings["DbConnection"];
            var sqlString = "SELECT * FROM sys_Equipment_Type ";
            SqlParameter[] sqlParams = new SqlParameter[] {
               // new SqlParameter("@ClientIp", clientIp)
            };
            List<EquipmentTypeModel> list = new List<EquipmentTypeModel>();
            SqlDataReader reader = SqlHelper.ExecuteReader(connectionString, CommandType.Text, sqlString, sqlParams);
            while (reader.Read())
            {
                EquipmentTypeModel e = new EquipmentTypeModel
                {

                    TypeName = reader.GetString(0),
                    ParentId = reader.GetString(1),
                    EquipmentId = reader.GetString(2),
                    ModelNumber = reader.GetString(3),
                    Remark = reader.GetString(4),
                    Id = reader.GetString(5),

                };
                list.Add(e);
            }
            reader.Close();
            return list;
        }

    }
}
