using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MorningStudio
{
    public static partial class Utility
    {
        public static class AES
        {
            /// <summary>
            /// 默认盐
            /// </summary>
            public const string DefaultSalt = "jmU2DQotw6GegAGKCqSdHg==";

            /// <summary>
            /// 根据密码创建指定长度的密钥
            /// </summary>
            /// <param name="password">密码</param>
            /// <param name="keySize">长度</param>
            /// <param name="salt">盐</param>
            /// <returns></returns>
            public static byte[] CreateKey(string password,int keySize,string salt = "")
            {
                if(string.IsNullOrEmpty(salt))
                {
                    salt = DefaultSalt;
                }
                DeriveBytes derivedKey = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt));
                return derivedKey.GetBytes(keySize);
            }

            /// <summary>
            /// 加密
            /// </summary>
            /// <param name="inputData">明文</param>
            /// <param name="key">密钥</param>
            /// <param name="iV">向量</param>
            /// <returns>密文</returns>
            public static byte[] EncryptStringToBytes(string inputData, byte[] key, byte[] iV)
            {
                if (inputData == null || inputData.Length <= 0)
                    throw new ArgumentNullException("inputData");
                if (key == null || key.Length <= 0)
                    throw new ArgumentNullException("key");
                if (iV == null || iV.Length <= 0)
                    throw new ArgumentNullException("iV");
                byte[] encrypted;
                using (RijndaelManaged rijAlg = new RijndaelManaged())
                {
                    rijAlg.Key = key;
                    rijAlg.IV = iV;
                    rijAlg.Mode = CipherMode.CBC;
                    rijAlg.Padding = PaddingMode.PKCS7;
                    ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);
                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(inputData);
                            }
                            encrypted = msEncrypt.ToArray();
                        }
                    }
                }
                return encrypted;
            }

            /// <summary>
            /// 解密
            /// </summary>
            /// <param name="inputData">密文</param>
            /// <param name="key">密钥</param>
            /// <param name="iV">向量</param>
            /// <returns>明文</returns>
            public static string DecryptStringFromBytes(byte[] inputData, byte[] key, byte[] iV)
            {
                if (inputData == null || inputData.Length <= 0)
                    throw new ArgumentNullException("inputData");
                if (key == null || key.Length <= 0)
                    throw new ArgumentNullException("key");
                if (iV == null || iV.Length <= 0)
                    throw new ArgumentNullException("iV");
                string plaintext = null;
                using (RijndaelManaged rijAlg = new RijndaelManaged())
                {
                    rijAlg.Key = key;
                    rijAlg.IV = iV;
                    ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
                    using (MemoryStream msDecrypt = new MemoryStream(inputData))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                plaintext = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
                return plaintext;
            }
        }
    }
}
