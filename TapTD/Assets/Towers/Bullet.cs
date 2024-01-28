using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    private float damage;
    private Enemy target;

    private void Update()
    {
        transform.position += speed * Time.deltaTime * transform.up;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Enemy>(out var enemy))
            if (enemy == target)
                HitTarget();
    }

    public void Setup(float dmg, Enemy trgt)
    {
        damage = dmg;
        target = trgt;
    }

    private void HitTarget()
    {
        target.ReduceHealth(damage);
        Destroy(gameObject);
    }
}
