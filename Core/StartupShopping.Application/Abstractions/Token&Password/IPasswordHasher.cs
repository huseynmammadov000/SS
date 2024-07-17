using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Application.Abstractions.Token_Password
{
    public interface IPasswordHasher
    {
       
            void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
            bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        

    }
}
