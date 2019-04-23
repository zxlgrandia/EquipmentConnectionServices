using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.Model
{
    class EquipmentTypeModel
    {
        public string Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// 父类型编号
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 设备编号
        /// </summary>
        public string EquipmentId { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string ModelNumber { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    
    }
}
