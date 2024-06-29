namespace Common.Helpers
{
    public static class PasswordHelper
    {
        public static string PassEncrypt(string str) => BCrypt.Net.BCrypt.HashPassword(str);
        public static bool VerifyPassword(string password, string hashedPassword) => BCrypt.Net.BCrypt.Verify(password, hashedPassword);

    }
}
