using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Object = UnityEngine.Object;

public class OutlineOnHover : MonoBehaviour
{
    [SerializeField] private Material _baseMaterial;
    [SerializeField] private Material _outlineMaterial;

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().material = _baseMaterial;
    }

    private void OnMouseEnter()
    {
        gameObject.GetComponent<SpriteRenderer>().material = _outlineMaterial;
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().material = _baseMaterial;

    }

}