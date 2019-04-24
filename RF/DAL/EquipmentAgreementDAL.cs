using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace WindowsFormsApplication1.DAL
{
    public class EquipmentAgreementDAL
    {
        public static List<EquipmentAgreementModel> GetEquipmentAgreementList(string equipmentId)
        {
            var connectionString = ConfigurationManager.AppSettings["DbConnection"];
            var sqlString = "SELECT * FROM SYS_EQUIPMENT_AGREEMENT WHERE  EQUIPMENT_ID = @EquipmentID";
            SqlParameter[] sqlParams = new SqlParameter[] {
                new SqlParameter("@EquipmentID", equipmentId)
            };
            List<EquipmentAgreementModel> list = new List<EquipmentAgreementModel>();
            SqlDataReader reader = SqlHelper.ExecuteReader(connectionString, CommandType.Text, sqlString, sqlParams);
            while(reader.Read())
            {
                EquipmentAgreementModel e = new EquipmentAgreementModel
                {
                    AgreementType = reader.GetString(0),
                    EquipmentIp = reader.GetString(1),
                    EquipmentPort = reader.GetInt16(2),
                    SendMessage = reader.GetString(3),
                    WebSocketIp = reader.GetString(4),
                    WebSocketPort = reader.GetInt16(5),
                    ConnectionEntry = reader.GetString(6),
                    Com = reader.GetInt16(7),
                    Bps = reader.GetInt16(8),
                    EndPosition = reader.GetInt16(9),
                    CheckPoint = reader.GetInt16(10),
                    DataBit = reader.GetInt16(11),
                    GatherType = reader.GetInt16(12),
                    UploadPath = reader.GetString(13),
                    Id = reader.GetString(14),
                    EquipmentId = reader.GetString(21)
                };
                list.Add(e);
            }
            reader.Close();
            return list;
        }
    }
}
