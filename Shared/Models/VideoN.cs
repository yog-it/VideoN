using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace YogIT.Module.VideoN.Models
{
    [Table("YogITVideoN")]
    public class VideoN : IAuditable
    {
        [Key]
        public int VideoNId { get; set; }
        public int ModuleId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
