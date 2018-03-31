using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Security_Logins_Log")]
    public class SecurityLoginsLogPoco : IPoco
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid Login { get; set; }

        [Column("Source_IP")]
        [Required]
        [Display(Name = "Source IP")]
        public string SourceIP { get; set; }

        [Column("Logon_Date")]
        [Required]
        [Display(Name = "Logon Date")]
        public DateTime LogonDate { get; set; }

        [Column("Is_Succesful")]
        [Required]
        [Display(Name = "Is Succesful")]
        public Boolean IsSuccesful { get; set; }
        public virtual SecurityLoginPoco SecurityLogin { get; set; }
    }
}
