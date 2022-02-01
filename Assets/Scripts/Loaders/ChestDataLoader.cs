using System;
using System.Collections;
using UnityEngine;

namespace Loaders
{
    public class ChestDataLoader : MonoBehaviour
    {
        [SerializeField] private string _itemsDataURL;

        public event Action<ChestProtocol> ChestProtocolLoaded;

        public void StartDownloadItemsData()
        {
            StartCoroutine(DownloadItemsData());
        }
        
        private IEnumerator DownloadItemsData()
        {
            var www = new WWW(_itemsDataURL);
            yield return www;

            if (www.error != null)
            {
                Debug.LogError(www.error);
                yield break;
            }
        
            SetChestProtocol(www.text);
        }

        private void SetChestProtocol(string json)
        {
            var chestProtocol = JsonUtility.FromJson<ChestProtocol>(json);
            Debug.Log($"Данные сундука {chestProtocol.chest} " +
                      $"в котором {chestProtocol.chest_items.Length} предметов успешно загружены");
        
            Debug.Log($"ChestData ---> {json}");
            
            ChestProtocolLoaded?.Invoke(chestProtocol);
        }
    }
}