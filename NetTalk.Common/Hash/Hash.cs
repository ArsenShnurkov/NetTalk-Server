using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace NetTalk.Common.Hash
{
    public class NetTalkHash
    {
        public static string Sha1Text(string text)
        {
            return HashData(text, "SHA1");
        }

        public static string Sha1TextUnicode(string text)
        {
            return HashDataUnicode(text, "SHA1");
        }
        public static string HashData(byte[] data, string hash)
        {
            HashAlgorithm hashFunction = HashAlgorithm.Create(hash);
            byte[] hashedPassword = hashFunction.ComputeHash(data);

            StringBuilder s = new StringBuilder(hashedPassword.Length * 2);
            foreach (byte b in hashedPassword)
                s.Append(b.ToString("X2"));
            return s.ToString();
        }

        public static string HashData(string UTF8, string hash)
        {
            byte[] bpass = Encoding.UTF8.GetBytes(UTF8);
            return HashData(bpass, hash);
        }

        public static string HashDataUnicode(string Unicode, string hash)
        {
            byte[] bpass = Encoding.Unicode.GetBytes(Unicode);
            return HashData(bpass, hash);
        }

        public static string RandomString(int Length)
        {
            byte[] keyValue = new byte[Length / 2];
            RNGCryptoServiceProvider r = new RNGCryptoServiceProvider();
            r.GetNonZeroBytes(keyValue);
            StringBuilder s = new StringBuilder(Length);
            foreach (byte b in keyValue)
                s.Append(b.ToString("X2"));
            return s.ToString();
        }
    }
}
