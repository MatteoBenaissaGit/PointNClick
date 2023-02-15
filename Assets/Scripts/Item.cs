using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [field:SerializeField] public string Name { get; private set; }
    [field:SerializeField] public Sprite Image { get; private set; }

    [SerializeField]
    private List<ItemPickupActivateCondition> _itemPickupActivateConditionList = new List<ItemPickupActivateCondition>();

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<PlayerController>())
        {
            GameManager.Instance.AddItem(this);
            _itemPickupActivateConditionList.ForEach(x => x.Activate());
            Destroy(gameObject);
        }
    }
}
