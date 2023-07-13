// OgrenciRepository.cs

using EgitimSistemi.DataAccessLayer.Concrete;
using EgitimSistemi.EntityLayer.Concreate;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EgitimSistemi.DataAccessLayer.Repositories
{
    public class OgrenciLoginRepository
    {
        private readonly Context _context;

        public OgrenciLoginRepository(Context context)
        {
            _context = context;
        }

        public async Task<Ogrenci> GetOgrenciByEmailAndPassword(string email, string sifre)
        {
            return await _context.Ogrencis.FirstOrDefaultAsync(o => o.Email == email && o.Sifre == sifre);
        }
    }
}
