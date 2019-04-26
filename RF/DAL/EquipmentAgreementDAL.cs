using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace DAL
{
    public class EquipmentAgreementDAL
    {
        public static List<EquipmentAgreementModel> GetEquipmentAgreementList(string agreementId)
        {
            var connectionString = ConfigurationManager.AppSettings["DbConnection"];
            var sqlString = "SELECT * FROM SYS_EQUIPMENT_AGREEMENT WHERE  ID = @AgreementID";
            SqlParameter[] sqlParams = new SqlParameter[] {
                new SqlParameter("@AgreementID", agreementId)
            };
            List<EquipmentAgreementModel> list = new List<EquipmentAgreementModel>();
            SqlDataReader reader = SqlHelper.ExecuteReader(connectionString, CommandType.Text, sqlString, sqlParams);
            while(reader.Read())
            {
                EquipmentAgreementModel e = new EquipmentAgreementModel();
                e.AgreementType = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                e.EquipmentIp = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                e.EquipmentPort = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                e.SendMessage = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                e.WebSocketIp = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                e.WebSocketPort = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                e.ConnectionEntry = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                e.Com = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                e.Bps = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);
                e.EndPosition = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);
                e.CheckPoint = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                e.DataBit = reader.IsDBNull(11) ? 0 : reader.GetInt32(11);
                e.GatherType = reader.IsDBNull(12) ? 0 : reader.GetInt32(12);
                e.UploadPath = reader.IsDBNull(13) ? string.Empty : (string)reader.GetValue(13);
                e.Id = reader.IsDBNull(14) ? string.Empty : (string)reader.GetValue(14);
                list.Add(e);
            }
            reader.Close();
            return list;
        }
    }
}
