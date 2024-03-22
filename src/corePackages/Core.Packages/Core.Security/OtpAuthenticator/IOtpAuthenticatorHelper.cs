using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.OtpAuthenticator
{
    internal interface IOtpAuthenticatorHelper
    {
        public Task<byte[]> GenerateSecretKey();
        public Task<string> ConvertSecretKeyToString(byte[] secretKeykey);
        public Task<bool> VerifyCode(byte[] secretKey, string code);
    }
}