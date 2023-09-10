using System;
using Core.Domain;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Components
{
    public class SubnetsManifestController : MonoBehaviour
    {
        public UnityEvent<Ipv4SubnetBlockRequest> onSubnetBlockRequestAdded = new ();
        public UnityEvent onSubnetBlockRequestAddFailed = new ();
        public SubnetsManifest subnetsManifest = new();
        public void AddSubnetBlockRequest(string cidrInput, Color color)
        {
            try
            {
                var cidr = new Ipv4Cidr(cidrInput);
                var request = new Ipv4SubnetBlockRequest { cidr = cidr, color = color };
                subnetsManifest.subnetBlockRequests.Add(request);
                onSubnetBlockRequestAdded?.Invoke(request);
            }
            catch (Exception _)
            {
                onSubnetBlockRequestAddFailed?.Invoke();
            }
        }
    }
}
