using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationRisk_Database.Model
{
    [Table("LOCATION_RISK_DATA")]
    public class Location_Risk_Data
    {
        [Key]
        [Column("locationRIskId")]
        public long? LocationRIskId { get; set; }

        [Column("text")]
        public string? Text { get; set; }

        [Column("title")]
        public string? Title { get; set; }

        [Column("image")]
        public string? Image { get; set; }

        [Column("status")]
        public int? Status { get; set; }

        [Column("distance")]
        public int? Distance { get; set; }

    }
}
