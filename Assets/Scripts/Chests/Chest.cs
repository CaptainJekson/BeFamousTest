using System.Collections;
using System.Collections.Generic;
using Items;
using UnityEngine;
using UnityEngine.UI;

namespace Chests
{
    public class Chest : MonoBehaviour
    {
        [SerializeField] private Button _openButton;
        [SerializeField] private float _pressOpenButtonCooldown = 2.0f;

        private List<Item> _items;
        
        private void Start()
        {
            _items = new List<Item>();
            _openButton.onClick.AddListener(Open);
        }

        private void Open()
        {
            StartCoroutine(StartCooldown());
            
            if (_items.Count > 0)
            {
                var item = _items[0];
                _items.Remove(item);
                
                var spawnedItem = Instantiate(item, transform);
                Debug.Log($"Айтем {item.name} извлечён из сундука");
                spawnedItem.Move();
            }
            else
            {
                Debug.Log("В сундуке больше нет айтемов");
            }
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        private IEnumerator StartCooldown()
        {
            _openButton.interactable = false;
            yield return new WaitForSeconds(_pressOpenButtonCooldown);
            _openButton.interactable = true;
        }
    }
}