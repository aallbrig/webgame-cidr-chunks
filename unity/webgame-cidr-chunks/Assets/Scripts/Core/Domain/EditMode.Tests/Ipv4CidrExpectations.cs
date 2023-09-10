using System;
using Core.Domain;
using NUnit.Framework;

namespace Core.CoreTests
{
    public class Ipv4CidrExpectations
    {
        [TestCase("13")]
        [TestCase("0.0.0.0")]
        [TestCase("0.0.0.0/-1")]
        [TestCase("0.0.0.0/33")]
        [TestCase("10.-1.0.0/16")] // no negative numbers
        [TestCase("256.0.0.0/16")] // numbers can't exceed 255
        [TestCase("-10.0.0.0/16")] // the "-" is parsed out by the regex, but fails "cidr == cidrInput" check
        public void Ipv4CidrThrowsExceptionsOnInvalidCidrInput(string invalidCidrInput)
        {
            try
            {
                var sut = new Ipv4Cidr(invalidCidrInput);
                Assert.Fail($"Expected exception to be thrown for invalid cidr input {invalidCidrInput}");
            } catch (Exception _)
            {
                Assert.Pass();
            }
        }
        [TestCase("13.37.0.0/16")]
        [TestCase("13.37.0.0/20")]
        [TestCase("13.37.16.0/20")]
        [TestCase("13.37.32.0/20")]
        [TestCase("13.37.48.0/20")]
        [TestCase("13.37.0.0/24")]
        [TestCase("13.37.1.0/24")]
        [TestCase("13.37.2.0/24")]
        [TestCase("13.37.0.0/25")]
        [TestCase("13.37.0.128/25")]
        [TestCase("13.37.1.0/25")]
        [TestCase("13.37.1.128/25")]
        public void Ipv4CidrValidCidrInput(string validCidrInput)
        {
            try
            {
                var sut = new Ipv4Cidr(validCidrInput);
            } catch (Exception ex)
            {
                Assert.Fail($"expect no exception thrown but one was thrown {ex}");
            }
        }
    }
}
