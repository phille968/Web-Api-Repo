﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace NyttWebApi.Security
{
    public class Encryption
    {
        public static string IV = "qo1lc3sjd8zpt9cx";
        public static string Key = "ow7dxys8g1for9tnc2ansdfgoletkfjv";

        public static string Encrypt(string decrypted)
        {
            byte[] textBytes = ASCIIEncoding.ASCII.GetBytes(decrypted);
            AesCryptoServiceProvider endec = new AesCryptoServiceProvider();
            endec.BlockSize = 128;
            endec.KeySize = 256;
            endec.Key = ASCIIEncoding.ASCII.GetBytes(Key);
            endec.IV = ASCIIEncoding.ASCII.GetBytes(IV);
            endec.Padding = PaddingMode.PKCS7;
            endec.Mode = CipherMode.CBC;

            ICryptoTransform icrypt = endec.CreateEncryptor(endec.Key, endec.IV);

            byte[] enc = icrypt.TransformFinalBlock(textBytes, 0, textBytes.Length);
            icrypt.Dispose();

            return Convert.ToBase64String(enc);
        }

        public static string Decrypt(string encrypted)
        {
            byte[] encBytes = ASCIIEncoding.ASCII.GetBytes(encrypted);
            AesCryptoServiceProvider endec = new AesCryptoServiceProvider();
            endec.BlockSize = 128;
            endec.KeySize = 256;
            endec.Key = ASCIIEncoding.ASCII.GetBytes(Key);
            endec.IV = ASCIIEncoding.ASCII.GetBytes(IV);
            endec.Padding = PaddingMode.PKCS7;
            endec.Mode = CipherMode.CBC;

            ICryptoTransform icrypt = endec.CreateEncryptor(endec.Key, endec.IV);

            byte[] dec = icrypt.TransformFinalBlock(encBytes, 0, encBytes.Length);
            icrypt.Dispose();

            return Convert.ToBase64String(dec);
        }
    }
}