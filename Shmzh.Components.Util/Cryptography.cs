using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace Shmzh.Components.Util
{
	/// <summary>
	/// 密码系统 。
	/// </summary>
	public class Cryptography
    {
        #region Field
        /// <summary>
		/// 指定的KEY。
		/// </summary>
		private static byte[] DES_IV = new byte[]{0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF};
		/// <summary>
		/// 初始化向量。
		/// </summary>
		private static byte[] DES_KEY = new byte[]{0x12, 0x34, 0x56, 0x78, 0x87, 0x65, 0x43, 0x21};
        
        private static string desKey = "hollesky";
        private static byte[] Exponent = new byte[3] { 1, 0, 1, };
        private static byte[] D = new byte[] { 105, 148, 6, 236, 236, 178, 233, 173, 132, 138, 3, 73, 1, 9, 186, 171, 219, 139, 17, 110, 0, 220, 161, 15, 169, 67, 216, 178, 65, 68, 187, 204, 238, 152, 169, 89, 24, 180, 53, 147, 80, 153, 106, 254, 245, 180, 89, 225, 191, 33, 66, 92, 153, 197, 237, 251, 100, 88, 25, 213, 58, 22, 150, 77, 92, 244, 127, 254, 55, 52, 65, 173, 5, 232, 188, 225, 204, 251, 104, 2, 92, 85, 202, 27, 240, 56, 56, 151, 23, 9, 147, 131, 82, 84, 135, 116, 104, 48, 197, 85, 141, 23, 73, 222, 127, 245, 33, 223, 241, 97, 177, 29, 61, 47, 214, 229, 203, 3, 47, 46, 5, 25, 108, 190, 24, 3, 44, 177, };
        private static byte[] DP = new byte[] { 23, 23, 121, 82, 62, 112, 184, 238, 160, 137, 124, 195, 43, 194, 140, 106, 255, 88, 22, 177, 152, 152, 116, 152, 24, 130, 54, 224, 123, 18, 95, 156, 96, 101, 173, 128, 239, 107, 89, 238, 201, 243, 184, 59, 120, 20, 248, 188, 87, 157, 19, 89, 124, 244, 211, 146, 49, 132, 179, 94, 213, 68, 43, 165, };
        private static byte[] DQ = new byte[] { 88, 143, 229, 230, 72, 101, 34, 103, 144, 52, 2, 64, 112, 234, 42, 46, 175, 216, 151, 234, 159, 217, 39, 220, 220, 129, 6, 131, 15, 149, 141, 110, 83, 230, 165, 52, 235, 25, 115, 95, 94, 19, 27, 103, 52, 100, 83, 230, 246, 12, 211, 27, 250, 118, 223, 32, 14, 226, 124, 184, 37, 92, 99, 111, };
        private static byte[] InverseQ = new byte[64] { 187, 128, 45, 21, 187, 224, 155, 196, 246, 91, 215, 164, 50, 240, 41, 65, 32, 16, 132, 181, 51, 201, 229, 49, 23, 107, 225, 114, 173, 191, 176, 185, 80, 26, 217, 253, 127, 246, 199, 187, 145, 86, 16, 141, 98, 249, 95, 221, 79, 76, 164, 29, 148, 101, 158, 22, 112, 183, 219, 172, 139, 251, 222, 72, };
        private static byte[] Modulus = new byte[128] { 135, 114, 246, 133, 246, 45, 75, 100, 153, 88, 86, 218, 19, 96, 168, 84, 77, 84, 111, 168, 136, 133, 192, 173, 144, 154, 235, 185, 125, 117, 141, 58, 113, 196, 6, 26, 69, 16, 32, 192, 119, 136, 211, 246, 77, 49, 2, 75, 178, 81, 172, 40, 203, 8, 91, 146, 246, 239, 218, 179, 191, 49, 54, 166, 52, 84, 55, 12, 79, 172, 102, 209, 165, 51, 223, 186, 45, 56, 95, 66, 111, 129, 250, 184, 8, 77, 52, 104, 41, 103, 188, 172, 46, 240, 14, 152, 225, 109, 229, 155, 239, 30, 108, 191, 52, 152, 129, 55, 166, 41, 157, 206, 73, 90, 189, 168, 109, 189, 142, 192, 103, 79, 97, 120, 121, 0, 108, 185, };
        private static byte[] P = new byte[64] { 188, 46, 157, 209, 132, 51, 108, 5, 35, 216, 243, 89, 249, 241, 92, 207, 106, 91, 59, 246, 142, 10, 57, 113, 173, 176, 167, 37, 13, 69, 9, 16, 125, 92, 14, 185, 238, 242, 90, 219, 1, 171, 231, 69, 152, 191, 136, 89, 167, 10, 88, 49, 236, 118, 241, 197, 118, 81, 198, 110, 106, 172, 13, 203, };
        private static byte[] Q = new byte[64] { 184, 67, 71, 243, 178, 159, 185, 26, 134, 45, 98, 223, 30, 88, 11, 15, 90, 67, 112, 27, 228, 10, 94, 54, 12, 148, 126, 51, 85, 26, 247, 96, 67, 2, 70, 200, 228, 67, 196, 206, 205, 34, 172, 185, 1, 194, 130, 253, 54, 67, 139, 251, 101, 130, 14, 146, 82, 172, 187, 178, 23, 200, 223, 11, };

        private static RSAParameters RSAKey = new RSAParameters { D = D, DP = DP, DQ = DQ, Exponent = Exponent, InverseQ = InverseQ, Modulus = Modulus, P = P, Q = Q };

        //private static string publicKey =
        //    "<RSAKeyValue><Modulus>9dpgsyXN1AEoXtuXGkHARYxpET7FjBk+SKus6nQ2ppw7IaTTMmN169uuGJWfhFFJnPBJnNDkbMpMpeGCtXN67iJnTJ8p06NUxUp7wGxtzzTwM39rCNutRalhNtTgJAEzPi8aZ57L9BGanUni/SYJ++ol17+914mtW1uEQO+TiPU=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

        //private static string privateKey =
        //    "<RSAKeyValue><Modulus>9dpgsyXN1AEoXtuXGkHARYxpET7FjBk+SKus6nQ2ppw7IaTTMmN169uuGJWfhFFJnPBJnNDkbMpMpeGCtXN67iJnTJ8p06NUxUp7wGxtzzTwM39rCNutRalhNtTgJAEzPi8aZ57L9BGanUni/SYJ++ol17+914mtW1uEQO+TiPU=</Modulus><Exponent>AQAB</Exponent><P>/WQ4Lnr+1vfpaO/3upEx9vlirfxEen9j2+/YnEM1jdnOtX0zxCGwjWdUAd3nuF2UT7uNAOw+WC44tdhl/iZI3w==</P><Q>+GJKq2Ow83NS9okDuZSR2etPX42PeCj7FI0WCX3vyq14i4MXKgN93xWMGupGroo5vGbBDoDFf5pS45OW2u6kqw==</Q><DP>pJCpGC7TQUPC+F8ZEbbor1Cp8Pssci436YgsstfHeTfi0uXcb929byiTW58Ftiw4fUv+OII1v0lNlXRUUSoGGw==</DP><DQ>C5+19N1ee5YrDMSOuxGb3cHoXgVm8G2iimyr2lfdb/O8T3McE2hEbLs6akwKcMKhPxLj+ATIuVcEiAfxKF/Arw==</DQ><InverseQ>VAVEDPpwsFA6K+SZCfkjyieqtQo+YVNkwnsCbxBdR53ZATaDa+2S7otos8PWuVLdp7XkCo0pQhCR7Matbcp6Ow==</InverseQ><D>IbLQJF4fK1sJRI9G0+OFTkMjt6hp/X0MS3u0lOJfB1FMzZzBEhwN8slGwLnphoJ525gYDvWXCc5k2Svi9aohhDPNyjpPxVcbE5ha5dK+VUleRlzsqIr0EAfxym8jCXbnM06Jp7sS8O5j+CUxknsiXTUcOQhA2/N7UHrjRpnqurU=</D></RSAKeyValue>";
        private static readonly UnicodeEncoding ByteConverter = new UnicodeEncoding();

        private static string defaultBigInteger = "501BD0B20EFA40EACF74F713D8758BC68319BD40CFDE577986EB46DC3C47126FB2CA3026B8FEE6BA1A652A295EF724F66270CCB91AA7C33C89B04AF9CEFA78DD99654F102D1950DABFF418C5BE847FBB614233DED7BCF09F9FE370816A501DCBDC2DD1A8B7794A50815112EADF4FACBC975AD116E2909E63988BA16B8930C7F1";
        private static string defaultPublicKey = "EBFE2038BF8CCB6F925E31EB6A298090601A8A4050878A02A0F4E6214FB96FC248098E3A9CEBCCBB897F44FBE82F8189104291B49AA737AB1FCAADC0DC89B753";
        private static string defaultPrivateKey = "B3E8C293AEED4648AC4E057EB130C62E688FA453970CE9E7C2092DCAC0E1D28C881668465614AE7FD6D8184A648E032E242C1423ED72C702B92927A0B201D9E0CB7207B735718FD147833F976E8C9CDEE80B9626372741F5B0CA626E2E60294D92FD0894C7BA0AD3D751CAE00C0A7E33C4DF3BF1FDBC5D291AEF54AB1B58F57";

        private static string specifyPublicKey = "F9AE9ED2D8EE72218362B121B3B8A539DD90FC6702FAE584E0E11D23E01AC2277DB4102C82E9EB555ABA534E3F004852CECEEA6393FD1F35BD81EEE7938395B1";
        #endregion

        #region Method
        /// <summary>
		/// 使用具有指定 Key 和初始化向量 (IV) 的 DESCryptoServiceProvider，加密 .
		/// </summary>
		/// <param name="strText">string:	原始字符串。</param>
		/// <returns>string:	加密后字符串。</returns>
		public static string DesEncrypt(string strText)
		{
            var des = new DESCryptoServiceProvider();
            var inputByteArray = Encoding.ASCII.GetBytes(strText);
            var ms = new MemoryStream();
            var cs = new CryptoStream(ms, des.CreateEncryptor(DES_KEY, DES_IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            
            return Convert.ToBase64String(ms.ToArray());
		}
	    /// <summary>
	    /// 使用具有指定Key和初始化向量IV的DESCryptoServiceProvider，解密。
	    /// </summary>
	    /// <param name="strText">string:	加密后字符串。</param>
	    /// <returns>string:	加密前的字符串。</returns>
		public static string DesDecrypt(string strText)
		{
	        var des = new DESCryptoServiceProvider();
	        var inputByteArray = Convert.FromBase64String(strText);
	        var ms = new MemoryStream();
	        var cs = new CryptoStream(ms, des.CreateDecryptor(DES_KEY, DES_IV), CryptoStreamMode.Write);
	        cs.Write(inputByteArray, 0, inputByteArray.Length);
	        cs.FlushFinalBlock();
	        return Encoding.ASCII.GetString(ms.ToArray());
		}

        /// <summary>
        /// 工作流费用管理的表单密码加密用到此方法，解密。
        /// </summary>
        /// <param name="pToDecrypt">string:	加密后字符串。</param>
        /// <returns>string:	加密前的字符串。</returns>
        public static string DecryptDes(string pToDecrypt)
        {
            var buffer = Convert.FromBase64String(pToDecrypt);
            using (var provider = new DESCryptoServiceProvider())
            {
                provider.Key = Encoding.ASCII.GetBytes(desKey);
                provider.IV = Encoding.ASCII.GetBytes(desKey);
                var stream = new MemoryStream();
                using (var stream2 = new CryptoStream(stream, provider.CreateDecryptor(), ((CryptoStreamMode)1)))
                {
                    stream2.Write(buffer, 0, buffer.Length);
                    stream2.FlushFinalBlock();
                    stream2.Close();
                }
                var str2 = Encoding.UTF8.GetString(stream.ToArray());
                stream.Close();
                return str2;
            }
        }

        /// <summary>
        /// 工作流费用管理的表单密码加密用到此方法，加密。
        /// </summary>
        /// <param name="pToEncrypt">string:	原始字符串。</param>
        /// <returns>string:	加密后字符串。</returns>
        public static string EncryptDes(string pToEncrypt)
        {
            using (var provider = new DESCryptoServiceProvider())
            {
                var bytes = Encoding.UTF8.GetBytes(pToEncrypt);
                provider.Key = Encoding.ASCII.GetBytes(desKey);
                provider.IV = Encoding.ASCII.GetBytes(desKey);
                var stream = new MemoryStream();
                using (var stream2 = new CryptoStream(stream, provider.CreateEncryptor(), (CryptoStreamMode)1))
                {
                    stream2.Write(bytes, 0, bytes.Length);
                    stream2.FlushFinalBlock();
                    stream2.Close();
                }
                var str2 = Convert.ToBase64String(stream.ToArray());
                stream.Close();
                return str2;
            }
        }

        /// <summary>
        /// 将 8 位无符号整数数组的值转换为它的等效 String 表示形式（由以 64 为基的数字组成）。
        /// </summary>
        /// <param name="convertStr">要转换的字符串</param>
        /// <returns>Base64String.</returns>
        public static string ToBase64String(string convertStr)
        {
            var inputByteArray = Encoding.UTF8.GetBytes(convertStr);
            var base64Str = Convert.ToBase64String(inputByteArray);
            return base64Str;
        }
        
        /// <summary>
        /// 将指定的由以 64 为基的数字组成的值的 String 表示形式转换为等效的 8 位无符号整数数组。
        /// </summary>
        /// <param name="convertStr">要转换的字符串</param>
        /// <returns></returns>
        public static string FromBase64String(string convertStr)
        {
            var inputByteArray = Convert.FromBase64String(convertStr);
            var base64Str = Encoding.UTF8.GetString(inputByteArray);
            return base64Str;
        }
        
        /// <summary>
        /// 进行MD5加密
        /// </summary>
        /// <param name="sDataIn">要加密的字符串</param>
        /// <returns>返回加密的字符串</returns>
        public static string GetMD5(string sDataIn)
        {
            var md5 = new MD5CryptoServiceProvider();
            var bytValue = System.Text.Encoding.UTF8.GetBytes(sDataIn);
            var bytHash = md5.ComputeHash(bytValue);
            md5.Clear();
            var sTemp = "";
            for (var i = 0; i < bytHash.Length; i++)
            {
                sTemp += bytHash[i].ToString("X").PadLeft(2, '0');
            }
            return sTemp.ToLower();
        }

        //public static string RSAEncrypt(string s)
        //{
        //    s = Cryptography.ToBase64String(s);
        //    var obj = new RSACryptoServiceProvider();
        //    obj.FromXmlString(privateKey);
        //    var a = Convert.FromBase64String(s);
        //    var ea = obj.Encrypt(a, false);
        //    return Convert.ToBase64String(ea);
        //}

        //public static string RSADecrypt(string s)
        //{
        //    var obj = new RSACryptoServiceProvider();
        //    obj.FromXmlString(privateKey);

        //    var a = Convert.FromBase64String(s);
        //    var ea = obj.Decrypt(a, false);
        //    var es = Convert.ToBase64String(ea);
        //    var ss = Cryptography.FromBase64String(es);
        //    return ss;
        //}

        #region RSA BigInteger
        /// <summary>
        /// 通过默认的公钥对字符串进行加密。
        /// </summary>
        /// <param name="dataStr">待加密字符串。</param>
        /// <returns>加密结果。</returns>
        public static string RSAEncryptByPublicKey(string dataStr)
        {
            return RSAEncryptByPublicKey(dataStr, defaultBigInteger, defaultPublicKey);
        }
        /// <summary>
        /// 通过默认的私钥对字符串进行加密。
        /// </summary>
        /// <param name="dataStr">加密字符串。</param>
        /// <returns>解密结果。</returns>
        public static string RSADecryptByPrivateKey(string dataStr)
        {
            return RSADecryptByPrivateKey(dataStr, defaultBigInteger, defaultPrivateKey);
        }
        /// <summary>
        /// 通过默认的私钥对字符串进行加密。
        /// </summary>
        /// <param name="dataStr">待加密字符串。</param>
        /// <returns>加密结果。</returns>
        public static string RSAEncryptByPrivateKey(string dataStr)
        {
            return RSAEncryptByPrivateKey(dataStr, defaultBigInteger, defaultPrivateKey);
        }
        /// <summary>
        /// 通过默认的私钥对字符串进行解密。
        /// </summary>
        /// <param name="dataStr">加密字符串。</param>
        /// <returns>解密结果。</returns>
        public static string RSADecryptByPublicKey(string dataStr)
        {
            return RSADecryptByPublicKey(dataStr, defaultBigInteger, defaultPublicKey);
        }
        /// <summary>
        /// 通过特定的公钥对字符串进行解密。
        /// </summary>
        /// <param name="dataStr">加密的字符串。</param>
        /// <returns>解密结果。</returns>
        /// <remarks>该特定的公钥是与KeyGen程序中加密采用的私钥配套的。具体私钥值需参考KenGen程序中。</remarks>
        public static string RSADescryptBySpecifyPublicKey(string dataStr)
        {
            return RSADecryptByPublicKey(dataStr, defaultBigInteger, specifyPublicKey);
        }
        /// <summary>
        /// 通过公钥对字符串进行加密。
        /// </summary>
        /// <param name="dataStr">待加密字符串</param>
        /// <param name="n">大整数n</param>
        /// <param name="e">公钥</param>
        /// <returns>加密结果。</returns>
        public static string RSAEncryptByPublicKey(string dataStr, string n, string e)
        {
            return Convert.ToBase64String(EncryptByPublicKey(dataStr, n, e));
        }
        /// <summary>
        /// 通过私钥对字符串进行解密。
        /// </summary>
        /// <param name="dataStr">加密后字符串。</param>
        /// <param name="n">大整数n。</param>
        /// <param name="d">私钥。</param>
        /// <returns>解密结果</returns>
        public static string RSADecryptByPrivateKey(string dataStr, string n, string d)
        {
            var a = Convert.FromBase64String(dataStr);
            return DecryptByPrivateKey(a, n, d);
        }
        /// <summary>
        /// 通过私钥对字符串加密。
        /// </summary>
        /// <param name="dataStr">待加密字符串</param>
        /// <param name="n">大整数n。</param>
        /// <param name="d">私钥。</param>
        /// <returns>加密结果。</returns>
        public static string RSAEncryptByPrivateKey(string dataStr, string n, string d)
        {
            return Convert.ToBase64String(EncryptByPrivateKey(dataStr, n, d));
        }
        /// <summary>
        /// 通过公钥对字符串进行解密。
        /// </summary>
        /// <param name="dataStr">加密后字符串。</param>
        /// <param name="n">大整数n。</param>
        /// <param name="e">公钥。</param>
        /// <returns>解密结果</returns>
        public static string RSADecryptByPublicKey(string dataStr, string n, string e)
        {
            var a = Convert.FromBase64String(dataStr);
            return DecryptByPublicKey(a, n, e);
        }
        /// <summary>
        /// 通过公钥加密
        /// </summary>
        /// <param name="dataStr">待加密字符串</param>
        /// <param name="n">大整数n</param>
        /// <param name="e">公钥</param>
        /// <returns>加密结果</returns>
        private static byte[] EncryptByPublicKey(string dataStr, string n, string e)
        {
            //大整数N
            BigInteger biN = new BigInteger(n, 16);
            //公钥大素数
            BigInteger biE = new BigInteger(e, 16);
            //加密
            return EncryptString(dataStr, biE, biN);
        }
        /// <summary>
        /// 通过私钥解密
        /// </summary>
        /// <param name="dataBytes">待解密字符数组</param>
        /// <param name="n">大整数n</param>
        /// <param name="d">私钥</param>
        /// <returns>解密结果</returns>
        private static string DecryptByPrivateKey(byte[] dataBytes, string n, string d)
        {
            //大整数N
            BigInteger biN = new BigInteger(n, 16);
            //私钥大素数
            BigInteger biD = new BigInteger(d, 16);
            //解密
            return DecryptBytes(dataBytes, biD, biN);
        }
        /// <summary>
        /// 通过私钥加密
        /// </summary>
        /// <param name="dataStr">待加密字符串</param>
        /// <param name="n">大整数n</param>
        /// <param name="d">私钥</param>
        /// <returns>加密结果</returns>
        private static byte[] EncryptByPrivateKey(string dataStr, string n, string d)
        {
            //大整数N
            BigInteger biN = new BigInteger(n, 16);
            //私钥大素数
            BigInteger biD = new BigInteger(d, 16);
            //加密
            return EncryptString(dataStr, biD, biN);
        }
        /// <summary>
        /// 通过公钥解密
        /// </summary>
        /// <param name="dataBytes">待加密字符串</param>
        /// <param name="n">大整数n</param>
        /// <param name="e">公钥</param>
        /// <returns>解密结果</returns>
        private static string DecryptByPublicKey(byte[] dataBytes, string n, string e)
        {
            //大整数N
            BigInteger biN = new BigInteger(n, 16);
            //公钥大素数
            BigInteger biE = new BigInteger(e, 16);
            //解密
            return DecryptBytes(dataBytes, biE, biN);
        }
        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="dataStr">待加密字符串</param>
        /// <param name="keyNum">密钥大素数</param>
        /// <param name="nNum">大整数N</param>
        /// <returns>加密结果</returns>
        private static byte[] EncryptString(string dataStr, BigInteger keyNum, BigInteger nNum)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(dataStr);
            int len = bytes.Length;
            int len1 = 0;
            int blockLen = 0;
            if ((len % 120) == 0)
                len1 = len / 120;
            else
                len1 = len / 120 + 1;
            List<byte> tempbytes = new List<byte>();
            for (int i = 0; i < len1; i++)
            {
                if (len >= 120)
                {
                    blockLen = 120;
                }
                else
                {
                    blockLen = len;
                }
                byte[] oText = new byte[blockLen];
                Array.Copy(bytes, i * 120, oText, 0, blockLen);
                string res = Encoding.UTF8.GetString(oText);
                BigInteger biText = new BigInteger(oText);
                BigInteger biEnText = biText.modPow(keyNum, nNum);
                //补位
                string resultStr = biEnText.ToHexString();
                if (resultStr.Length < 256)
                {
                    while (resultStr.Length != 256)
                    {
                        resultStr = "0" + resultStr;
                    }
                }
                byte[] returnBytes = new byte[128];
                for (int j = 0; j < returnBytes.Length; j++)
                    returnBytes[j] = Convert.ToByte(resultStr.Substring(j * 2, 2), 16);
                tempbytes.AddRange(returnBytes);
                len -= blockLen;
            }
            return tempbytes.ToArray();
        }

        /// <summary>
        /// 解密字符数组
        /// </summary>
        /// <param name="dataBytes">待解密字符数组</param>
        /// <param name="KeyNum">密钥大素数</param>
        /// <param name="nNum">大整数N</param>
        /// <returns>解密结果</returns>
        private static string DecryptBytes(byte[] dataBytes, BigInteger KeyNum, BigInteger nNum)
        {
            int len = dataBytes.Length;
            int len1 = 0;
            int blockLen = 0;
            if (len % 128 == 0)
            {
                len1 = len / 128;
            }
            else
            {
                len1 = len / 128 + 1;
            }
            List<byte> tempbytes = new List<byte>();
            for (int i = 0; i < len1; i++)
            {
                if (len >= 128)
                {
                    blockLen = 128;
                }
                else
                {
                    blockLen = len;
                }
                byte[] oText = new byte[blockLen];
                Array.Copy(dataBytes, i * 128, oText, 0, blockLen);
                BigInteger biText = new BigInteger(oText);
                BigInteger biEnText = biText.modPow(KeyNum, nNum);
                byte[] testbyte = biEnText.getBytes();
                string str = Encoding.UTF8.GetString(testbyte);
                tempbytes.AddRange(testbyte);
                len -= blockLen;
            }
            return System.Text.Encoding.UTF8.GetString(tempbytes.ToArray());
        }

        #endregion
        #endregion
    }
}
