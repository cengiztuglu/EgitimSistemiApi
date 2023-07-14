﻿using EgitimSistemi.DataAccessLayer.Concrete;
using EgitimSistemi.EntityLayer.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimSistemi.DataAccessLayer.Repositories
{
    public class AdminLoginRepository
    {
        private readonly Context _context;

        public AdminLoginRepository(Context context)
        {
            _context = context;
        }


        public async Task<Admin> GetSuperAdminByEmailAndPassword(string email, string password)
        {
            return await _context.Admins.FirstOrDefaultAsync(o => o.Mail == email && o.Sifre == password && o.Yetki);
        }

        public async Task<Admin> GetRegularAdminByEmailAndPassword(string email, string password)
        {
            return await _context.Admins.FirstOrDefaultAsync(o => o.Mail == email && o.Sifre == password && !o.Yetki);
        }
    }
}
