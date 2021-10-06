using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCategories.Models
{
    public class AddProfileImage
    {
        [Key]
        public int WriterID { get; set; }

        
        public string WriterName { get; set; }

      
        public string WriterSurName { get; set; }

        public Microsoft.AspNetCore.Http.IFormFile WriterImage { get; set; }

        public string WriterMail { get; set; }

        public string WriterPassword { get; set; }
    }
}
