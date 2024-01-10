using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private Tower tower;

    private void Awake()
    {
        tower = GetComponentInParent<Tower>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
            return;

        tower.EnemyEnterRange(collision.gameObject.GetComponent<Enemy>());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
            return;

        tower.EnemyExitRange(collision.gameObject.GetComponent<Enemy>());
    }
}
