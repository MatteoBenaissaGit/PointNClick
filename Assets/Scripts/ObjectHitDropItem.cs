using System;
using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace
{
    public class ObjectHitDropItem : MonoBehaviour, IInteractable
    {
        [SerializeField] private bool _dropAtShot = true;
        [SerializeField] private Item _itemPrefab;
        [SerializeField] private Vector3 _itemDropPosition;

        private bool _hasDropped;
        
        public void Execute()
        {
            if (_dropAtShot)
            {
                DropItem();
            }
        }

        public void DropItem()
        {
            if (_hasDropped)
            {
                return;
            }

            if (_itemPrefab != null)
            {
                Item item = Instantiate(_itemPrefab, transform.position, Quaternion.identity);
                item.transform.DOMove(_itemDropPosition, 0.5f);
                _hasDropped = true;
            }
        }
        
#if UNITY_EDITOR

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(_itemDropPosition, Vector3.one * 0.2f);
        }

#endif
    }
}