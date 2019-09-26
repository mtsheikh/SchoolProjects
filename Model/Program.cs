using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BAIS3150_CodeSampleSystem.Model
{
    class Program
    {
        [Key]
        [StringLength(10)]
        public string ProgramCode { get; set; }
        [StringLength(60)]
        public string Description { get; set; }
    }
}
