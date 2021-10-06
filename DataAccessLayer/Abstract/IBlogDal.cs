using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal:IGenericDal<Blog>
    {
        //generic yapı içiersinde sedece ilgili entitye ait bir metot istersek burda tanımlanır
        List<Blog> GetListWithCategory();
    }
}
