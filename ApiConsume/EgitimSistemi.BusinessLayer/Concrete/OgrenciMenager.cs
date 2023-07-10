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
    public class OgrenciMenager : IOgrenciService
    {
        private readonly IOgrenciDal _ogrenciDal;

        public OgrenciMenager(IOgrenciDal ogrenciDal)
        {
            _ogrenciDal = ogrenciDal;
        }

        public void TDelete(Ogrenci t)
        {
            _ogrenciDal.Delete(t);
        }

        public Ogrenci TGetByID(int id)
        {
            return _ogrenciDal.GetByID(id);
        }

        public List<Ogrenci> TGetList()
        {
            return _ogrenciDal.GetList();
        }

        public void TInsert(Ogrenci t)
        {
            _ogrenciDal.Insert(t);
        }

        public void TUpdate(Ogrenci t)
        {
          _ogrenciDal.Update(t);
        }
    }
}
