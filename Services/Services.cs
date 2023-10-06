using Microsoft.EntityFrameworkCore;
using registrosanna.Data;
using registrosanna.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace registrosanna.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AuthenticateAsync(string documento, string contrasena)
        {

            var user = await _dbContext.Registros.FirstOrDefaultAsync(r => r.Documento == documento);


            if (user == null)
            {
                return false;
            }


            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(contrasena, user.ContrasenaHash);

            return isPasswordValid;
        }

    }
}
