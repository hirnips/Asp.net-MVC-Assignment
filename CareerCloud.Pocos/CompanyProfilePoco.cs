using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Company_Profiles")]
    public class CompanyProfilePoco : IPoco
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Column("Registration_Date")]
        [Required]
        [Display(Name = "Registration Date")]
        public DateTime RegistrationDate { get; set; }

        [Column("Company_Website")]
        [Display(Name = "Company Website")]
        [Required]
        public string CompanyWebsite { get; set; }

        [Column("Contact_Phone")]
        [Display(Name = "Contact Phone")]
        [Required]
        public string ContactPhone { get; set; }

        [Column("Contact_Name")]
        [Display(Name = "Contact Name")]
        [Required]
        public string ContactName { get; set; }

        [Column("Company_Logo")]
        [Display(Name = "Company Logo")]
        public Byte[] CompanyLogo { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }

        public virtual ICollection<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        public virtual ICollection<CompanyJobPoco> CompanyJobs { get; set; }
        public virtual ICollection<CompanyLocationPoco> CompanyLocations { get; set; }
    }
}
