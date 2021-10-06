
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int CatID { get; set; }

        [StringLength(50)]
        public string CatName { get; set; }

        [StringLength(200)]
        public string CatDescription { get; set; }
        public bool CatStatus { get; set; }

        //ilişki
        public List<Blog> Blogs { get; set; }
    }
}
