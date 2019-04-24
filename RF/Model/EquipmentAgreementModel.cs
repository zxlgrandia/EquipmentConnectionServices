using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class EquipmentAgreementModel
    {
        /// <summary>
        /// 协议编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 设备ID
        /// </summary>
        public string EquipmentId { get; set; }
        /// <summary>
        /// 协议类型
        /// </summary>
        public string AgreementType { get; set; }
        /// <summary>
        /// 设备IP
        /// </summary>
        public string EquipmentIp { get; set; }
        /// <summary>
        /// 设备端口
        /// </summary>
        public int EquipmentPort { get; set; }
        /// <summary>
        /// 默认消息
        /// </summary>
        public string SendMessage { get; set; }
        /// <summary>
        /// WebSocketIp
        /// </summary>
        public string WebSocketIp { get; set; }
        public int WebSocketPort { get; set; }
        /// <summary>
        /// 连接入口
        /// </summary>
        public string ConnectionEntry { get; set; }
        /// <summary>
        /// COM 端口
        /// </summary>
        public int Com { get; set; }
        /// <summary>
        /// 比特率
        /// </summary>
        public int Bps { get; set; }
        /// <summary>
        /// 停止位
        /// </summary>
        public int EndPosition { get; set; }
        /// <summary>
        /// 校验
        /// </summary>
        public int CheckPoint { get; set; }
        /// <summary>
        /// 数据位
        /// </summary>
        public int DataBit { get; set; }
        /// <summary>
        /// 采集类型
        /// </summary>
        public int GatherType { get; set; }
        /// <summary>
        /// 上传路径
        /// </summary>
        public string UploadPath { get; set; }
    }
}
