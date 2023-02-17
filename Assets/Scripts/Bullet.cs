using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private List<ParticleSystem> _particleSystem;
    [SerializeField, Range(0,2)] private float _speed;
    [HideInInspector] public Vector2 EndPoint;
    [SerializeField] private AudioClip _bulletAudioClip;

    private void Start()
    {
        transform.DOMove(EndPoint, _speed)
            .SetEase(Ease.Linear)
            .OnComplete(End);

        Vector2 pos = transform.position;
        transform.rotation = Quaternion.Euler(EndPoint - pos);

        //audio
        SoundManager.Instance.PlaySound(_bulletAudioClip);
    }

    private void End()
    {
        //raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 0.01f);
        if (hit.collider != null)
        {
            foreach (IInteractable interactable in hit.collider.GetComponents<IInteractable>())
            {
                interactable.Execute();
            }
        }

        //particles
        _particleSystem.ForEach(x => x.Play());
        _particleSystem.ForEach(x => x.transform.parent = GameManager.Instance.transform);
        
        //destroy
        transform.DOScale(Vector2.zero, 0.3f).OnComplete(DestroyBullet);
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
