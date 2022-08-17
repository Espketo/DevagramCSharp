using System.Security.Cryptography;
using System.Text;

namespace DevagramCSharp.Utils
{
    public class MD5Utils
    {
        public static string GerarHashMD5(string texto)
        {
            MD5 md5hash = MD5.Create();
            var bytes = md5hash.ComputeHash(Encoding.UTF8.GetBytes(texto));

            StringBuilder stringbuilder = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                stringbuilder.Append(bytes[i]);
            }

            return stringbuilder.ToString();
        }
    }
}
