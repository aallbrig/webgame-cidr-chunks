using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Core.Domain.EditMode.Tests
{
    public class SubnetsManifestExpectations
    {

        [NUnit.Framework.Test]
        public void SubnetsManifestIsSerializable()
        {
            var sut = new SubnetsManifest
            {
                subnetBlockRequests = new List<Ipv4SubnetBlockRequest>
                {
                    new Ipv4SubnetBlockRequest
                    {
                        color = Color.red,
                        cidr = new Ipv4Cidr("10.0.0.0/24")
                    },
                    new Ipv4SubnetBlockRequest
                    {
                        color = Color.yellow,
                        cidr = new Ipv4Cidr("10.0.1.0/24")
                    },
                    new Ipv4SubnetBlockRequest
                    {
                        color = Color.green,
                        cidr = new Ipv4Cidr("10.0.2.0/24")
                    }
                }
            };

            var json = JsonUtility.ToJson(sut);

            Assert.AreNotEqual("{}", json);
        }
    }
}
