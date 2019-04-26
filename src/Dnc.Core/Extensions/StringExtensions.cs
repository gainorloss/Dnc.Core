using Dnc.Helpers;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Dnc.Extensions
{
    /// <summary>
    /// Extension methods for string.
    /// </summary>
    public static class StringExtensions
    {

        /// <summary>
        /// Default encoding.
        /// </summary>
        private static Encoding _encoding = Encoding.UTF8;


        #region Base64.
        /// <summary>
        /// Convert string to base64.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToBase64String(this string source)
        {
            if (source == null)
            {
                return null;
            }
            var str = Convert.ToBase64String(_encoding.GetBytes(source));
            return str;
        }


        /// <summary>
        /// Convert string from base64;
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string FromBase64String(this string source)
        {
            if (source == null)
            {
                return null;
            }
            var str = _encoding.GetString(Convert.FromBase64String(source));
            return str;
        }

        /// <summary>
        /// 是否base64字符串
        /// </summary>
        /// <param name="base64Str">要判断的字符串</param>
        /// <returns></returns>
        public static bool IsBase64String(this string base64Str)
        {
            return IsBase64String(base64Str, out byte[] bytes);
        }


        /// <summary>
        /// 是否base64字符串
        /// </summary>
        /// <param name="base64Str">要判断的字符串</param>
        /// <param name="bytes">字符串转换成的字节数组</param>
        /// <returns></returns>
        public static bool IsBase64String(this string base64Str, out byte[] bytes)
        {
            bytes = null;
            if (string.IsNullOrEmpty(base64Str))
                return false;
            else
            {
                if (base64Str.Contains(","))
                    base64Str = base64Str.Split(',')[1];
                if (base64Str.Length % 4 != 0)
                    return false;
                if (base64Str.Any(c => !base64CodeArray.Contains(c)))
                    return false;
            }
            try
            {
                bytes = Convert.FromBase64String(base64Str);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        #endregion


        #region UrlEncoding.
        /// <summary>
        /// Encode url string.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToUrlEncodingString(this string url)
        {
            if (url == null)
            {
                return null;
            }
            var str = WebUtility.UrlEncode(url).ToBase64String();
            return str;
        }


        /// <summary>
        /// Decode url string.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string FromUrlEncodingString(this string source)
        {
            if (source == null)
            {
                return null;
            }
            var str = WebUtility.UrlDecode(source.FromBase64String());
            return str;
        }
        #endregion


        #region Truncate.
        ///   <summary> 
        ///   将指定字符串按指定长度进行截取并加上指定的后缀
        ///   </summary> 
        ///   <param   name= "oldStr "> 需要截断的字符串 </param> 
        ///   <param   name= "maxLength "> 字符串的最大长度 </param> 
        ///   <param   name= "endWith "> 超过长度的后缀 </param> 
        ///   <returns> 如果超过长度，返回截断后的新字符串加上后缀，否则，返回原字符串 </returns> 
        public static string Truncate(this string oldStr, int maxLength = 80, string endWith = "...")
        {
            //判断原字符串是否为空
            if (string.IsNullOrEmpty(oldStr))
                return oldStr + endWith;


            //返回字符串的长度必须大于1
            if (maxLength < 1)
                throw new Exception("返回的字符串长度必须大于[0] ");


            //判断原字符串是否大于最大长度
            if (oldStr.Length > maxLength)
            {
                var endWithLength = endWith.Length;
                //截取原字符串
                string strTmp = oldStr.Substring(0, maxLength - endWithLength);


                //判断后缀是否为空
                if (string.IsNullOrEmpty(endWith))
                    return strTmp;
                else
                    return strTmp + endWith;
            }
            return oldStr;
        }
        #endregion


        #region MD5.
        /// <summary>
        /// md5进行32位的加盐加密
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToMD5Encrypt(this string source, string salt = "Dnc.Core")
        {
            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentNullException("Arguments not allowed null or empty.");
            }
            source = MD5Encrypt.Encrypt(source, 32);
            source = source + salt;
            var str = MD5Encrypt.Encrypt(source, 32);
            return str;
        }


        /// <summary>
        /// md5进行16位的加盐加密
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToMD5EncryptBy16(this string source, string salt = "Dnc.Core")
        {
            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentNullException("Arguments not allowed null or empty.");
            }
            source = MD5Encrypt.Encrypt(source, 16);
            source = source + salt;
            var str = MD5Encrypt.Encrypt(source, 16);
            return str;
        } 
        #endregion


        /// <summary>
        /// Get redirect return url.
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <param name="url"></param>
        /// <param name="defaultUrl"></param>
        /// <returns></returns>
        //public static string GetRedirectUrl(this string returnUrl, IUrlHelper url, string defaultUrl = "/")
        //{
        //    return url.IsLocalUrl(returnUrl) ? returnUrl : defaultUrl;
        //}

        /// <summary>
        /// 判断是否是正确的电子邮件格式
        /// </summary>
        /// <param name="source">字符串</param>
        /// <returns>bool</returns>
        public static bool IsEmail(this string source)
        {
            return Regex.IsMatch(source, @"^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$", RegexOptions.Compiled);
        }


        private static char[] base64CodeArray = new char[]
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            '0', '1', '2', '3', '4',  '5', '6', '7', '8', '9', '+', '/', '='
        };


        #region Random.
        /// <summary>
        /// 随机字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length">长度</param>
        /// <param name="isNum">是否是数字</param>
        /// <returns></returns>
        public static string ToRandomString(this string str, int length = 4, bool isNum = true)
        {
            string allChar;
            if (isNum)
            {

                allChar = @"0,1,2,3,4,5,6,7,8,9";
            }
            else
            {
                allChar = @"0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,a,b,c,d,e,f,g,h,i,g,k,l,m,n,o,p,q,r,F,G,H,I,G,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,s,t,u,v,w,x,y,z";
            }
            string[] allCharArray = allChar.Split(',');
            string randomCode = "";
            int temp = -1;
            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
                }
                int t;
                if (isNum)
                {
                    t = rand.Next(9);
                }
                else
                {
                    t = rand.Next(35);
                }
                if (temp == t)
                {
                    return ToRandomString(string.Empty, length);
                }
                temp = t;
                randomCode += allCharArray[t];
            }
            return randomCode;
        }
        #endregion


        #region Mobile *.
        /// <summary>
        /// 手机号码转换成带****字符
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public static string ToMobileSecurityString(this string mobile)
        {
            if (string.IsNullOrEmpty(mobile) || mobile.Length != 11)
            {
                throw new InvalidDataException();
            }
            string str = mobile.Substring(0, 3) + "****" + mobile.Substring(mobile.Length - 4, 4);
            return str;
        } 
        #endregion

    }
}
