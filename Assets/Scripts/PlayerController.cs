
using System;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _shootOrigin;
    
    private NavMeshAgent _navMeshAgent;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Move(mousePosWorld);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Bullet bullet = Instantiate(_bulletPrefab, _shootOrigin.position, Quaternion.identity);
            bullet.EndPoint = mousePosWorld;
        }
    }

    public void Move(Vector2 position)
    {
        _navMeshAgent.destination = new Vector3(position.x, position.y, transform.position.z);
        Vector3 scale = transform.localScale;
        transform.localScale = new Vector3(_navMeshAgent.destination.x < transform.position.x ? -Mathf.Abs(scale.x) : Mathf.Abs(scale.x), scale.y, scale.z);
    }
}
