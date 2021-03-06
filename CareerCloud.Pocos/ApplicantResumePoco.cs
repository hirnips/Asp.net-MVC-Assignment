﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Resumes")]
    public class ApplicantResumePoco : IPoco
    {

        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid Applicant { get; set; }

        [Required]
        public string Resume { get; set; }

        [Column("Last_Updated")]
        [Display(Name = "Last Updated")]
        public DateTime? LastUpdated { get; set; }
        public virtual ApplicantProfilePoco ApplicantProfile { get; set; }
    }
}
