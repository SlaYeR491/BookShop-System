using System.Security.Cryptography;
using System.Text;

namespace BookShop.API.Aggregates
{
    public class Hashing(IConfiguration configuration)
    {
        public string Hash(byte[] bytes)
        {
            var key = Encoding.UTF8.GetBytes(configuration["HashKey"]);
            var alg = new HMACSHA256(key);
            return Encoding.UTF8.GetString(alg.ComputeHash(bytes));
        }
        public byte[] HashToBytes(byte[] bytes)
        {
            var key = Encoding.UTF8.GetBytes(configuration["HashKey"]);
            var alg = new HMACSHA256(key);
            return alg.ComputeHash(bytes);
        }
    }
}
