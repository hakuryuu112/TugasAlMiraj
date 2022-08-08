﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tugasAlMiraj.Common
{
    public class Password
    {
        public string Encode(string password)
        {
            try
            {
                byte[] EncDataByte = new byte[password.Length];
                EncDataByte = System.Text.Encoding.UTF8.GetBytes(password);
                string EncryptedData = Convert.ToBase64String(EncDataByte);

                return EncryptedData;
            }
            catch (Exception ex)
            {

                throw new Exception("Error in Encode : " + ex.Message);
            }
        }

        public string Decode(string EncryptedData)
        {
            try
            {
                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                System.Text.Decoder UTF8Decode = encoding.GetDecoder();

                byte[] DecodeByte = Convert.FromBase64String(EncryptedData);
                int CharCount = UTF8Decode.GetCharCount(DecodeByte, 0, DecodeByte.Length);
                char[] DecodeChar = new char[CharCount];
                UTF8Decode.GetChars(DecodeByte, 0, DecodeByte.Length, DecodeChar, 0);
                string DecryptedData = new string(DecodeChar);

                return DecryptedData;
            }
            catch (Exception ex)
            {

                throw new Exception("Error in Decode : " + ex.Message);
            }
        }
    }
}