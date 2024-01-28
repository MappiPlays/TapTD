using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private Tower tower;
    private bool isVisible;

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

    public void SetVisibility(bool visible)
    {
        if (isVisible != visible)
        {
            ToggleVisibility();
        }
    }

    public void ToggleVisibility()
    {
        isVisible = !isVisible;
        GetComponent<SpriteRenderer>().enabled = isVisible;
        //GetComponent<LineRenderer>().enabled = isVisible;
    }

    public void Deactivate()
    {
        GetComponent<Collider2D>().enabled = false;
    }

    public void Activate()
    {
        GetComponent<Collider2D>().enabled = true;
    }
}
