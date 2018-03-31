﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Educations")]
    public class ApplicantEducationPoco : IPoco
    {

        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid Applicant { get; set; }

        [Required]
        public string Major { get; set; }

        [Column("Certificate_Diploma")]
        [Display(Name = "Certificate Diploma")]
        public string CertificateDiploma { get; set; }

        [Column("Start_Date")]
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [Column("Completion_Date")]
        [Display(Name = "Completion Date")]
        public DateTime? CompletionDate { get; set; }

        [Column("Completion_Percent")]
        [Display(Name = "Completion Percent")]
        public Byte? CompletionPercent { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }
        public virtual ApplicantProfilePoco ApplicantProfile { get; set; }
    }
}
