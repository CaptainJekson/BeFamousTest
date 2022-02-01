using System;
using System.Collections;
using UnityEngine;

namespace Loaders
{
    public class BundleLoader : MonoBehaviour
    {
        [SerializeField] private int _version = 0;
        [SerializeField] private string _bundleURL;
    
        public event Action<AssetBundle> BundlesLoaded; 

        private void Start()
        {
            StartCoroutine(DownloadBundle());
        }

        private IEnumerator DownloadBundle()
        {
            while (!Caching.ready)
            {
                yield return null;
            }
        
            var www = WWW.LoadFromCacheOrDownload(_bundleURL, _version);
            yield return www;
        
            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.LogError(www.error);
                yield break;
            }
        
            Debug.Log("Бандлы загружены");
        
            BundlesLoaded?.Invoke(www.assetBundle);
        }
    }
}
