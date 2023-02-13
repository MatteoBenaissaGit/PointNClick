using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHitChangeSprite : MonoBehaviour, IInteractable
{
    [SerializeField] private bool _loopSprites;
    [SerializeField] private List<Sprite> _spriteList;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private int _spriteIndex;

    private void Start()
    {
        _spriteRenderer.sprite = _spriteList[0];
        _spriteIndex = 0;
    }

    public void Execute()
    {
        _spriteIndex++;
        if (_spriteIndex >= _spriteList.Count)
        {
            if (_loopSprites)
            {
                _spriteIndex = 0;
            }
            else
            {
                _spriteIndex--;
            }
        }
        _spriteRenderer.sprite = _spriteList[_spriteIndex];
    }
}
