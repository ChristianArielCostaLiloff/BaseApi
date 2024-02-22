using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BaseApi.Helpers
{
    public static class PasswordHelper
    {
        public static string PassEncrypt(string str) => BCrypt.Net.BCrypt.HashPassword(str);
        public static bool VerifyPassword(string password, string hashedPassword) => BCrypt.Net.BCrypt.Verify(password, hashedPassword);

    }
}
