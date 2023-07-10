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
    public class DerslerMenager : IDerslerService
    {
        private readonly IDerslerDal _derslerDal;

        public DerslerMenager(IDerslerDal derslerDal)
        {
            _derslerDal = derslerDal;
        }

        public void TDelete(Dersler t)
        {
            _derslerDal.Delete(t);
        }

        public Dersler TGetByID(int id)
        {
           return _derslerDal.GetByID(id);
        }

        public List<Dersler> TGetList()
        {
            return _derslerDal.GetList();

        }

        public void TInsert(Dersler t)
        {
            
            _derslerDal.Insert(t);

        }

        public void TUpdate(Dersler t)
        {
            _derslerDal.Update(t);
        }
    }
}
