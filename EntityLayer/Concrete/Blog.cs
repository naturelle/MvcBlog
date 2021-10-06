using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }

        [StringLength(50)]
        public string BlogTitle { get; set; }

        [StringLength(2000)]
        public string BlogContent { get; set; }
        public DateTime BlogDate { get; set; }

        [StringLength(100)]
        public string BlogImage { get; set; }

        public bool BlogStatus { get; set; }

        public int? CatID { get; set; }
        public Category Category { get; set; }

        public int? WriterID { get; set; }
        public Writer Writer { get; set; }
        //public virtual Writer Writer { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
