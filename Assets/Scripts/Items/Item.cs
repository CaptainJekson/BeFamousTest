using DG.Tweening;
using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Item : MonoBehaviour
    {
        [SerializeField] private float _itemMoveHeight = 4.0f;
        [SerializeField] private float _moveDuration = 1.0f;

        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Move()
        {
            var sequence = DOTween.Sequence();
            sequence.Append(transform.DOMoveY(_itemMoveHeight, _moveDuration).SetEase(Ease.OutQuart));
            sequence.AppendCallback(() => Destroy(gameObject));
        }
    }
}