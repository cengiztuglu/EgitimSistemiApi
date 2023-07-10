using EgitimSistemi.BusinessLayer.Abstract;
using EgitimSistemi.DataAccessLayer.Abstract;
using EgitimSistemi.EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimSistemi.BusinessLayer.Concrete
{
    public class AdminMenager : IAdminService
    {
        private readonly IAdminDal _adminDal;

        public AdminMenager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void TDelete(Admin t)
        {
            _adminDal.Delete(t);
        }

        public Admin TGetByID(int id)
        {
          return  _adminDal.GetByID(id);
        }

        public List<Admin> TGetList()
        {
            return _adminDal.GetList();
        }

        public void TInsert(Admin t)
        {
            _adminDal.Insert(t);
        }

        public void TUpdate(Admin t)
        {
           _adminDal.Update(t);
        }
    }
}
