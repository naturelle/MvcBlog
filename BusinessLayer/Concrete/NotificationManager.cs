using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        INotificationDal _notiticationDal;

        public NotificationManager(INotificationDal notiticationDal)
        {
            _notiticationDal = notiticationDal;
        }

        public Notification GetById(int id)
        {
            throw new NotImplementedException(); 
        }

        public List<Notification> GetList()
        {
            return _notiticationDal.GetListAll(x => x.Notificationstatus == true);
            
        }

        public void TAdd(Notification t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Notification t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Notification t)
        {
            throw new NotImplementedException();
        }
    }
}
