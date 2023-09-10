using System;
using System.Collections.Generic;

namespace Core.Domain
{
    [Serializable]
    public class SubnetsManifest
    {
        public List<Ipv4SubnetBlockRequest> subnetBlockRequests = new();
    }
}
