using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Work_History")]
   public  class ApplicantWorkHistoryPoco : IPoco
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid Applicant { get; set; }

        [Column("Company_Name")]
        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Column("Country_Code")]
        [Required]
        [Display(Name = "Country Code")]
        public string CountryCode { get; set; }

        [Required]
        public string Location { get; set; }

        [Column("Job_Title")]
        [Required]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Column("Job_Description")]
        [Required]
        [Display(Name = "Job Description")]
        public string JobDescription { get; set; }

        [Column("Start_Month")]
        [Required]
        [Display(Name = "start Month")]
        public Int16 StartMonth { get; set; }

        [Column("Start_Year")]
        [Required]
        [Display(Name = "Start Year")]
        public int StartYear { get; set; }

        [Column("End_Month")]
        [Required]
        [Display(Name = "End Month")]
        public Int16 EndMonth { get; set; }

        [Column("End_Year")]
        [Required]
        [Display(Name = "End Year")]
        public int EndYear { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }

        public virtual ApplicantProfilePoco ApplicantProfile { get; set; }
        //public virtual ICollection<SystemCountryCodePoco> SystemCountryCodes { get; set; }
        public virtual SystemCountryCodePoco SystemCountryCode { get; set; }
    }
}
