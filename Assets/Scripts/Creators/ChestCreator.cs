using Chests;
using Items;
using Loaders;
using UnityEngine;

namespace Creators
{
    public class ChestCreator : MonoBehaviour
    {
        [SerializeField] private BundleLoader _bundleLoader;
        [SerializeField] private ChestDataLoader _chestDataLoader;

        private string _chestName = "warlock";
        private Chest _chest;
        private AssetBundle _assetBundle;

        private void OnEnable()
        {
            _bundleLoader.BundlesLoaded += CreateFromBundle;
            _chestDataLoader.ChestProtocolLoaded += PutItemsInChest;
        }

        private void OnDisable()
        {
            _bundleLoader.BundlesLoaded -= CreateFromBundle;
            _chestDataLoader.ChestProtocolLoaded -= PutItemsInChest;
        }

        private void CreateFromBundle(AssetBundle bundle)
        {
            _assetBundle = bundle;
            var chestPrefab = bundle.LoadAsset<GameObject>(_chestName).GetComponent<Chest>();
            _chest = Instantiate(chestPrefab, transform);
            Debug.Log("Сундук создан");
            
            _chestDataLoader.StartDownloadItemsData();
        }

        private void PutItemsInChest(ChestProtocol chestProtocol)
        {
            foreach (var itemData in chestProtocol.chest_items)
            {
                var itemPrefab = _assetBundle.LoadAsset<GameObject>(itemData.itemkey).GetComponent<Item>();
                _chest.AddItem(itemPrefab);
            }
            
            Debug.Log("Айтемы в сундук добавлены");
        }
    }
}