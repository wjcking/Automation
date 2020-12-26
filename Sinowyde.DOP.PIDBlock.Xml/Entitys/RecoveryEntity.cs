using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDBlock.Xml.Entitys
{
    public class RecoveryEntity
    {
        public string People { get; set; }
        public string Description { get; set; }
        public DateTime BackupTimestamp { get; set; }
        public string FileName { get; set; }
    }
}
