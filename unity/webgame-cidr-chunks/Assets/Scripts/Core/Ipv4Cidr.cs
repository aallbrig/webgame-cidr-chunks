using System;
using System.Text.RegularExpressions;

namespace Core
{
    public class Ipv4Cidr
    {
        private static readonly string _pattern = @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\/([0-9]|[1-2][0-9]|3[0-2])\b";
        private static readonly int _fullGroupIndex = 0;
        private static readonly int _firstOctetIndex = 1;
        private static readonly int _secondOctetIndex = 2;
        private static readonly int _thirdOctetIndex = 3;
        private static readonly int _fourthOctetIndex = 4;
        private static readonly int _cidrPrefixIndex = 5;
        public int FirstOctet;
        public int SecondOctet;
        public int ThirdOctet;
        public int FourthOctet;
        public int CidrPrefix;
        public string Cidr;
        private string _cidrInput;

        public Ipv4Cidr(string cidrInput)
        {
            // cidrInput e.g. "13.37.0.0/16" parse cidr
            if (!Regex.IsMatch(cidrInput, _pattern))
            {
                throw new ArgumentException(nameof(cidrInput), $"Cidr input must match pattern {_pattern}");
            }
            var match = Regex.Match(cidrInput, _pattern);
            if (match.Groups.Count != 6)
            {
                // e.g. 10.-1.0.0/16
                throw new ArgumentException(nameof(cidrInput), $"Cidr input unexpected group count match (should be 6) {match.Groups.Count}");
            }
            ParseByte(out FirstOctet, match.Groups[_firstOctetIndex].Value);
            ParseByte(out SecondOctet, match.Groups[_secondOctetIndex].Value);
            ParseByte(out ThirdOctet, match.Groups[_thirdOctetIndex].Value);
            ParseByte(out ThirdOctet, match.Groups[_fourthOctetIndex].Value);
            ParseCidr(out CidrPrefix, match.Groups[_cidrPrefixIndex].Value);
            Cidr = match.Groups[_fullGroupIndex].Value;
            if (cidrInput != Cidr)
            {
                throw new ArgumentException(nameof(cidrInput), $"Cidr input {cidrInput} doesn't match regex matched {Cidr}");
            }
            _cidrInput = cidrInput;
        }
        private void ParseByte(out int octet, string matchedRegexGroup)
        {
            var possibleOctet = int.Parse(matchedRegexGroup);
            if (possibleOctet < 0 || possibleOctet > 255)
            {
                throw new ArgumentOutOfRangeException(nameof(matchedRegexGroup), $"Octet must be between 0 and 255, {possibleOctet}");
            }
            octet = possibleOctet;
        }
        private void ParseCidr(out int cidr, string matchedRegexGroup)
        {
            var possibleCidr = int.Parse(matchedRegexGroup);
            if (possibleCidr < 0 || possibleCidr > 32)
            {
                throw new ArgumentOutOfRangeException(nameof(matchedRegexGroup), $"Cidr must be between 0 and 32, {possibleCidr}");
            }
            cidr = possibleCidr;
        }
    }
}
