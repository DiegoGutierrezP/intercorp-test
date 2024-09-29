using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worker.Domain.Entities
{
    public class FileInformation : BaseEntity
    {
        public int Id { get; set; }
        public string Random { get; set; }
        public decimal? RandomFloat { get; set; }
        public bool Bool { get; set; }
        public string Date { get; set; }
        public string RegEx { get; set; }
        public string Enum { get; set; }
        [Column(TypeName = "jsonb")]
        public string Elt { get; set; }

        [Column(TypeName = "jsonb")]
        public string Person { get; set; }
        public string FileName { get; set; }
        public int FileNumber { get; set; }
        public string? LastUpdated { get; set; }//MICROSERVICES_PROCESS_01_<<DD/MM/AAAA HH:MM>>
        public string? LastModified { get; set; }//MICROSERVICES_PROCESS_02_<<DD/MM/AAAAHH:MM>>
    }
}
