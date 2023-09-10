using System;
using UnityEngine;

namespace Core.Domain
{
    [Serializable]
    public class Ipv4SubnetBlockRequest
    {
        public Color color;
        public Ipv4Cidr cidr;
    }
}
