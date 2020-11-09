using System;
using System.Security.Cryptography;
using System.Text;

namespace Tosapp_Tool
{
    public class Crypto
    {
        public static string MD5(string input)
        {
            string text = string.Empty;
            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] bytes = new UTF8Encoding().GetBytes(input);
            byte[] array = mD5CryptoServiceProvider.ComputeHash(bytes);
            for (int i = 0; i < array.Length; i++)
            {
                text += Convert.ToString(array[i], 16).PadLeft(2, '0');
            }
            mD5CryptoServiceProvider.Clear();
            return text.PadLeft(32, '0');
        }
    }
}
