using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace YoutubeDesktop
{
    /// <summary>
    /// This class' methods were copy-pasted from Google's HttpUtility class,
    /// from the assembly Google.GDate.Client, used within the Youtube .NET SDK.
    /// </summary>
    class HttpUtility
    {
        private static char[] hexChars = "0123456789abcdef".ToCharArray();
        
        public static string UrlEncode(string s)
        {
            return UrlEncode(s, Encoding.UTF8);
        }

        public static string UrlEncode(string s, Encoding Enc)
        {
            if (s == null)
            {
                return null;
            }
            if (s == "")
            {
                return "";
            }
            bool flag = false;
            int length = s.Length;
            for (int i = 0; i < length; i++)
            {
                char c = s[i];
                if (((((c < '0') || ((c < 'A') && (c > '9'))) || ((c > 'Z') && (c < 'a'))) || (c > 'z')) && !NotEncoded(c))
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                return s;
            }
            byte[] bytes = new byte[Enc.GetMaxByteCount(s.Length)];
            int count = Enc.GetBytes(s, 0, s.Length, bytes, 0);
            return Encoding.ASCII.GetString(UrlEncodeToBytes(bytes, 0, count));
        }

        public static byte[] UrlEncodeToBytes(byte[] bytes, int offset, int count)
        {
            if (bytes == null)
            {
                return null;
            }
            int length = bytes.Length;
            if (length == 0)
            {
                return new byte[0];
            }
            if ((offset < 0) || (offset >= length))
            {
                throw new ArgumentOutOfRangeException("offset");
            }
            if ((count < 0) || (count > (length - offset)))
            {
                throw new ArgumentOutOfRangeException("count");
            }
            MemoryStream result = new MemoryStream(count);
            int num2 = offset + count;
            for (int i = offset; i < num2; i++)
            {
                UrlEncodeChar((char)bytes[i], result, false);
            }
            return result.ToArray();
        }

        private static void UrlEncodeChar(char c, Stream result, bool isUnicode)
        {
            if (c > '\x00ff')
            {
                int num2 = c;
                result.WriteByte(0x25);
                result.WriteByte(0x75);
                int index = num2 >> 12;
                result.WriteByte((byte)hexChars[index]);
                index = (num2 >> 8) & 15;
                result.WriteByte((byte)hexChars[index]);
                index = (num2 >> 4) & 15;
                result.WriteByte((byte)hexChars[index]);
                index = num2 & 15;
                result.WriteByte((byte)hexChars[index]);
            }
            else if ((c > ' ') && NotEncoded(c))
            {
                result.WriteByte((byte)c);
            }
            else if (c == ' ')
            {
                result.WriteByte(0x2b);
            }
            else if ((((c < '0') || ((c < 'A') && (c > '9'))) || ((c > 'Z') && (c < 'a'))) || (c > 'z'))
            {
                if (isUnicode && (c > '\x007f'))
                {
                    result.WriteByte(0x25);
                    result.WriteByte(0x75);
                    result.WriteByte(0x30);
                    result.WriteByte(0x30);
                }
                else
                {
                    result.WriteByte(0x25);
                }
                int num3 = c >> 4;
                result.WriteByte((byte)hexChars[num3]);
                num3 = c & '\x000f';
                result.WriteByte((byte)hexChars[num3]);
            }
            else
            {
                result.WriteByte((byte)c);
            }
        }

        private static bool NotEncoded(char c)
        {
            if ((((c != '!') && (c != '\'')) && ((c != '(') && (c != ')'))) && (((c != '*') && (c != '-')) && (c != '.')))
            {
                return (c == '_');
            }
            return true;
        }

    }
}
