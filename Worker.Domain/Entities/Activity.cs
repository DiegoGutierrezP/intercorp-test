using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worker.Domain.Entities
{
    public class Activity : BaseEntity
    {
        public int Id { get; set; }
        public int Type { get; set; }//1:read file
        public string FileName { get; set; }
        public int FileNumber { get; set; }
        public string Data { get; set; }
        public string Log { get; set; }
        public ActivityStatus Status { get; set; }
    }

    public enum ActivityStatus
    {
        Pending = 1,
        Processed = 2,
        Failed = 3
    }
}
