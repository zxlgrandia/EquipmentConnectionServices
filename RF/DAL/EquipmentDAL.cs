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
    public class EquipmentDAL
    {
        public static List<EquipmentModel> GetEquipmentList(string clientIp)
        {
            var connectionString = ConfigurationManager.AppSettings["DbConnection"];
            var sqlString = "SELECT * FROM SYS_Equipment WHERE  Client_Ip = @ClientIp";
            SqlParameter[] sqlParams = new SqlParameter[] {
                new SqlParameter("@ClientIp", clientIp)
            };
            List<EquipmentModel> list = new List<EquipmentModel>();
            SqlDataReader reader = SqlHelper.ExecuteReader(connectionString, CommandType.Text, sqlString, sqlParams);
            while (reader.Read())
            {
                EquipmentModel e = new EquipmentModel
                {

                    Name = reader.IsDBNull(0) ? string.Empty : reader["NAME"].ToString(),
                    Manufacturer = reader.IsDBNull(1) ? string.Empty : reader["MANUFACTURER"].ToString(),
                    Model = reader.IsDBNull(2) ? string.Empty : reader["MODEL"].ToString(),
                    ClientIp = reader.IsDBNull(3) ? string.Empty : reader["CLIENT_IP"].ToString(),
                    AgreementId = reader.IsDBNull(4) ? string.Empty : reader["AGREEMENT_ID"].ToString(),
                    Id = reader.IsDBNull(5) ? string.Empty : reader["ID"].ToString()

                };
                list.Add(e);
            }
            reader.Close();
            return list;
        }
    }
}
