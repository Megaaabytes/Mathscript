using System.Security.Cryptography;

namespace Math_Script_Runtime_Environment.Crypto
{
    /*
        This class will be used later once AES is implemented.
    /*/
    public class Salt
    {
        internal static byte[] GenerateSalt() 
        {
            byte[] data = new byte[64];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                for (int i = 0; i < 10; i++)
                {
                    rng.GetBytes(data);
                }
            }
            return data;
        }
    }
}
