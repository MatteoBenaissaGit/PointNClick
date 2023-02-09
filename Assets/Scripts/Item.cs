using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour, IInteractable
{
    [field:SerializeField] public string Name { get; private set; }
    [field:SerializeField] public Sprite Image { get; private set; }

    public void Execute()
    {
        GameManager.Instance.AddItem(this);
        Destroy(gameObject);
    }
}
