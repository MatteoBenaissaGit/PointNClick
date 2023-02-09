using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUi : MonoBehaviour
{
    public void Initialize(Item item)
    {
        GetComponent<Image>().sprite = item.Image;
    }
}
