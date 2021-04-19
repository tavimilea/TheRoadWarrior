using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheRoadWarrior.Model.Hashing
{
    public class PasswordHasher
    {
        public static String getHash(String fromStr)
        {
            String loginHash = BCrypt.Net.BCrypt.HashPassword(fromStr);
            return loginHash;
        }

        public static bool checkHash(String hash1, String hash2)
        {
            return BCrypt.Net.BCrypt.Verify(hash1, hash2);
        }
    }
}
