using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class EquipmentModel
    {
        public string Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 生产厂家
        /// </summary>
        public string Manufacturer { get; set; }
        /// <summary>
        /// 型号
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        ///所属客户端 
        /// </summary>
        public string ClientIp { get; set; }
        /// <summary>
        /// 协议编号
        /// </summary>
        public string AgreementId { get; set; }

        public EquipmentAgreementModel EquipmentAgreement { get; set; }

    }
}
