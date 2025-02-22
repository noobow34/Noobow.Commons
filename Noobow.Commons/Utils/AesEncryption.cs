using System.Security.Cryptography;
using System.Text;

namespace Noobow.Commons.Utils
{
    public static class AesEncryption
    {
        private static byte[] GetEncryptionKey()
        {
            string? encKey = Environment.GetEnvironmentVariable("ENCRYPTION_KEY");
            if (string.IsNullOrEmpty(encKey))
            {
                throw new InvalidOperationException("Encryption key must be set in environment variables.");
            }

            return Encoding.UTF8.GetBytes(encKey);
        }

        private static byte[] DeriveIV(byte[] key, string context)
        {
            using SHA256 sha = SHA256.Create();
            byte[] contextBytes = Encoding.UTF8.GetBytes(context);
            byte[] combined = new byte[key.Length + contextBytes.Length];

            Buffer.BlockCopy(key, 0, combined, 0, key.Length);
            Buffer.BlockCopy(contextBytes, 0, combined, key.Length, contextBytes.Length);

            return sha.ComputeHash(combined)[..16];
        }

        public static string Encrypt(string plainText, string context)
        {
            using Aes aes = Aes.Create();
            aes.Key = GetEncryptionKey();
            aes.IV = DeriveIV(aes.Key, context);

            string encryptedStr;

            using ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using MemoryStream outStream = new();
            using (CryptoStream cs = new(outStream, encryptor, CryptoStreamMode.Write))
            {
                using StreamWriter sw = new(cs);
                sw.Write(plainText);
            }
            encryptedStr = Convert.ToBase64String(outStream.ToArray());
            
            return encryptedStr;
        }

        public static string Decrypt(string cipherText, string context)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            using Aes aes = Aes.Create();
            aes.Key = GetEncryptionKey();
            aes.IV = DeriveIV(aes.Key, context);

            using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using var ms = new MemoryStream(cipherBytes);
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var reader = new StreamReader(cs);

            return reader.ReadToEnd();
        }
    }
}