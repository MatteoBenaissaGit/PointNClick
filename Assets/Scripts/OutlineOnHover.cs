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
        Cursor.SetCursor(GameManager.Instance.CursorBase, Vector2.zero, CursorMode.Auto);
        gameObject.GetComponent<SpriteRenderer>().material = _baseMaterial;
    }

    private void OnMouseEnter()
    {
        Cursor.SetCursor(GameManager.Instance.CursorHover, Vector2.zero, CursorMode.Auto);
        gameObject.GetComponent<SpriteRenderer>().material = _outlineMaterial;
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(GameManager.Instance.CursorBase, Vector2.zero, CursorMode.Auto);
        gameObject.GetComponent<SpriteRenderer>().material = _baseMaterial;
    }

}