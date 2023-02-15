using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectHitFeedback : MonoBehaviour, IInteractable
{
    [SerializeField] private float _amplitude = 0.5f; 
    public void Execute()
    {
        transform.DOComplete();
        transform.DOPunchScale(Vector3.one * _amplitude, 0.3f);
    }
}
