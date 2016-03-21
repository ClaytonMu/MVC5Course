using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
    public class EDEViewModel
    {
        public int Id { get; set; }
        [Key]
        public int SecondId { get; set; }
        public string CompanyName { get; set; }
        public string CompanySN { get; set; }
    }
}