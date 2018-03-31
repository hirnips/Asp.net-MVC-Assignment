﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Skills")]
    public class ApplicantSkillPoco : IPoco
    {

        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid Applicant { get; set; }

        [Required]
        public string Skill { get; set; }

        
        [Column("Skill_Level")]
        [Required]
        [Display(Name = "Skill Level")]
        public string SkillLevel { get; set; }

        [Column("Start_Month")]
        [Required]
        [Display(Name = "Start Month")]
        public Byte StartMonth { get; set; }

        [Column("Start_Year")]
        [Required]
        [Display(Name = "Start Year")]
        public int StartYear { get; set; }

        [Column("End_Month")]
        [Required]
        [Display(Name = "End Month")]
        public Byte EndMonth { get; set; }

        [Column("End_Year")]
        [Required]
        [Display(Name = "End Year")]
        public int EndYear { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }

        public virtual ApplicantProfilePoco ApplicantProfile { get; set; }
    }
}
