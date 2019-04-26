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
            while (reader.Read())
            {
                EquipmentAgreementModel e = new EquipmentAgreementModel();
                e.AgreementType =   System.DBNull.Value == reader["AGREEMENT_TYPE"]  ? string.Empty : reader["AGREEMENT_TYPE"].ToString();
                e.EquipmentIp =     System.DBNull.Value == reader["EQUIPMENT_IP"]    ? string.Empty : reader["EQUIPMENT_IP"].ToString();
                e.EquipmentPort =   System.DBNull.Value == reader["EQUIPMENT_PORT"]  ? string.Empty : reader["EQUIPMENT_PORT"].ToString();
                e.SendMessage =     System.DBNull.Value == reader["SEND_MESSAGE"]    ? string.Empty : reader["SEND_MESSAGE"].ToString();
                e.WebSocketIp =     System.DBNull.Value == reader["WEB_SOCKET_IP"]   ? string.Empty : reader["WEB_SOCKET_IP"].ToString();
                e.WebSocketPort =   System.DBNull.Value == reader["WEB_SOCKET_PORT"] ? string.Empty : reader["WEB_SOCKET_PORT"].ToString();
                e.ConnectionEntry = System.DBNull.Value == reader["CONN_ENTRY"]      ? string.Empty : reader["CONN_ENTRY"].ToString();
                e.Com =             System.DBNull.Value == reader["COM"]             ? string.Empty : reader["COM"].ToString();
                e.Bps =             System.DBNull.Value == reader["BPS"]             ? 0            : (int)reader["BPS"];
                e.EndPosition =     System.DBNull.Value == reader["STOP_BIT"]        ? 0            : (int)reader["STOP_BIT"];
                e.CheckPoint =      System.DBNull.Value == reader["CHECK_POINT"]     ? string.Empty : reader["CHECK_POINT"].ToString();
                e.DataBit =         System.DBNull.Value == reader["DATA_BIT"]        ? 0            : (int)reader["DATA_BIT"];
                e.GatherType =      System.DBNull.Value == reader["GATHER_TYPE"]     ? 0            : (int)reader["GATHER_TYPE"];
                e.UploadPath =      System.DBNull.Value == reader["UPLOAD_PATH"]     ? string.Empty : reader["UPLOAD_PATH"].ToString();
                e.Id =              System.DBNull.Value == reader["ID"]              ? string.Empty : reader["ID"].ToString();
                list.Add(e);
            }
            reader.Close();
            return list;
        }
    }
}
