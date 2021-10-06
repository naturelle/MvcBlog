using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }

        [StringLength(50)]
        public string Subject { get; set; }

        [StringLength(50)]
        public string UserName{ get; set; }

        [StringLength(50)]
        public string UserMail { get; set; }
        public int BlogScore { get; set; }

        [StringLength(500)]
        public string Message { get; set; }
        public int? BlogID { get; set; }

        public Blog Blog { get; set; }

    }
}
