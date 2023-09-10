using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Core.Components
{
    public class SubnetsManifestPageController : MonoBehaviour
    {
        public SubnetsManifestController subnetsManifestController;
        public UIDocument uiDocument;
        private void Awake()
        {
            subnetsManifestController ??= GameObject.FindObjectOfType<SubnetsManifestController>();
        }
    }
}
