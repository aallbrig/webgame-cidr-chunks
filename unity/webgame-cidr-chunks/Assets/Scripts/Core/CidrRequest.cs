using System;
using UnityEngine;

namespace Core
{
    [Serializable]
    public class CidrBlockRequest
    {
        public Color Color;
        public Ipv4Cidr Cidr;
        public CidrBlockRequest() {}
    }
}
