using EgitimSistemi.DataAccessLayer.Abstract;
using EgitimSistemi.DataAccessLayer.Concrete;
using EgitimSistemi.DataAccessLayer.Repositories;
using EgitimSistemi.EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimSistemi.DataAccessLayer.EntityFramework
{
    public class EfDerslerDal : GenericRepository<Dersler>, IDerslerDal
    {
        public EfDerslerDal(Context context) : base(context)
        {
        }
    }
}
