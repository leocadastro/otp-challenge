using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Shopomo.OTP.Infra.Data.Helpers
{
    public class OTPGenerator
    {
        private readonly byte[] _key = Encoding.ASCII.GetBytes("privatekey123!@#");
        private static readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        private readonly int _intervalInSeconds = 30;
        private readonly int passwordLength = 6;

        public string GenerateOTP(byte[] bytes)
        {
            var hashAlgorithm = new HMACSHA1(_key);
            hashAlgorithm.ComputeHash(bytes);

            var hashBytes = hashAlgorithm.Hash.Select(x => (int)x).ToList();

            int offset = hashBytes[19] & 0xf;
            int binaryCode = (hashBytes[offset] & 0x7f) << 24
                | (hashBytes[offset + 1] & 0xff) << 16
                | (hashBytes[offset + 2] & 0xff) << 8
                | (hashBytes[offset + 3] & 0xff);

            int otp = binaryCode % (int)Math.Pow(10, passwordLength);

            return otp.ToString().PadLeft(passwordLength, '0');
        }

        public int GetIteration(DateTime time)
        {
            var timeDiff = time - _epoch;
            var seconds = (int)timeDiff.TotalSeconds;

            return seconds / _intervalInSeconds;
        }
    }
}
