using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GecmisManager : IGecmisService
    {
        private IGecmisDal gecmisDal;

        public GecmisManager(IGecmisDal gecmisDal)
        {
            this.gecmisDal = gecmisDal;
        }

        public void Add(Gecmis gecmis)
        {
           gecmisDal.Add(gecmis);
        }
    }
}
