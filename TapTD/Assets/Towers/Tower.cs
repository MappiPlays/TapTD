using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    private float damage;
    [SerializeField]
    private float attackDelay;

    private List<Enemy> enemiesInRange = new List<Enemy>();
    private Coroutine aimCoroutine;

    public void EnemyEnterRange(Enemy enemy)
    {
        enemiesInRange.Add(enemy);

        if(aimCoroutine == null)
        {
            aimCoroutine = StartCoroutine(AimAttack());
        }
    }

    public void EnemyExitRange(Enemy enemy)
    {
        if (enemiesInRange.Contains(enemy))
        {
            enemiesInRange.Remove(enemy);
        }
    }

    private IEnumerator AimAttack()
    {
        Enemy targetEnemy;
        Vector2 towardsEnemy;
        float timer = attackDelay;
        while(enemiesInRange.Count > 0)
        {
            targetEnemy = enemiesInRange[0];
            towardsEnemy = targetEnemy.transform.position - transform.position;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(towardsEnemy.y, towardsEnemy.x) * Mathf.Rad2Deg - 90);

            if(timer >= attackDelay)
            {
                targetEnemy.ReduceHealth(damage);
                timer -= attackDelay;
            }
            timer += Time.deltaTime;
            yield return null;
        }
        aimCoroutine = null;
    }
}
