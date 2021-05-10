using System;

namespace TheRoadWarrior.Model.Hashing
{
    public class PasswordHasher
    {
        public static String GetHash(String fromStr)
        {
            string loginHash = BCrypt.Net.BCrypt.HashPassword(fromStr);
            return loginHash;
        }

        public static bool CheckHash(String hash1, String hash2)
        {
            return BCrypt.Net.BCrypt.Verify(hash1, hash2);
        }
    }
}
