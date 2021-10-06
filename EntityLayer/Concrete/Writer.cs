using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }

        [StringLength(50)]
        public string WriterName { get; set; }

        [StringLength(50)]
        public string WriterSurName { get; set; }

        [StringLength(100)]
        public string WriterImage{ get; set; }

        [StringLength(50)]
        public string WriterMail { get; set; }

        [StringLength(50)]
        public string WriterPassword { get; set; }

        //public ICollection<Blog> Blogs { get; set; }
        public List<Blog> Blogs { get; set; }

        public virtual ICollection<Message2> WriterSender { get; set; }
        public virtual ICollection<Message2> WriterReceiver { get; set; }
    }
}
