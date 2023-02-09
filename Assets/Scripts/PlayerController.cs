using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public void Move(Vector2 position)
    {
        transform.DOKill();
        transform.DOMove(position, 1f);
    }
}
