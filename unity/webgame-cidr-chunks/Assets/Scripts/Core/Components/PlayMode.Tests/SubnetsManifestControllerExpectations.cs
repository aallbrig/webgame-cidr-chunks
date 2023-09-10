using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Core.Components.PlayMode.Tests
{
    public class SubnetsManifestControllerExpectations
    {
        [UnityTest]
        public IEnumerator SubnetsManifestControllerIsEmptyInitially()
        {
            var go = new GameObject();
            var sut = go.AddComponent<SubnetsManifestController>();
            yield return null;
            Assert.NotNull(sut);
            Assert.IsTrue(sut.subnetsManifest.subnetBlockRequests.Count == 0);
        }
        [UnityTest]
        public IEnumerator SubnetManifestController_CanAddSubnetBlocks()
        {
            var subnetBlockRequestAddedEventRaised = false;
            var addFailedEventRaised = false;
            var go = new GameObject();
            var sut = go.AddComponent<SubnetsManifestController>();
            yield return null;
            sut.onSubnetBlockRequestAdded.AddListener(_ => subnetBlockRequestAddedEventRaised = true);
            sut.onSubnetBlockRequestAddFailed.AddListener(() => addFailedEventRaised = true);
            Assert.IsTrue(sut.subnetsManifest.subnetBlockRequests.Count == 0);
            sut.AddSubnetBlockRequest("10.0.1.0/24", Color.red);
            yield return null;
            Assert.IsTrue(sut.subnetsManifest.subnetBlockRequests.Count == 1);
            Assert.IsTrue(subnetBlockRequestAddedEventRaised);
            Assert.IsFalse(addFailedEventRaised);
        }
    }
}
