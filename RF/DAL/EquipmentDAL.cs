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
        public static List<EquipmentModel> GetEquipmentAgreementList(string clientIp)
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
                    
                    Name = reader.GetString(0),
                    Manufacturer = reader.GetString(1),
                    Model = reader.GetString(2),
                    ClientIp = reader.GetString(3),
                    AgreementId = reader.GetString(4),
                    Id = reader.GetString(5),

                };
                list.Add(e);
            }
            reader.Close();
            return list;
        }
    }
}
