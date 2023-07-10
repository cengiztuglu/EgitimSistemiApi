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
    public class EfAdminDal : GenericRepository<Admin>, IAdminDal
    {
        public EfAdminDal(Context context) : base(context)
        {

        }
    }
}
