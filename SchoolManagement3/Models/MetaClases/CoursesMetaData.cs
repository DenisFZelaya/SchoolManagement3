using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement3.Models.MetaClases
{
    public class CoursesMetaData
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [Range(1, 8)]
        public int Credits { get; set; }
    }

    [MetadataType(typeof(CoursesMetaData))]
    public partial class Course
    {

    }
}