using TapTD.InventoryManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Splines;

public class Enemy : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private EnemyConfig config;

    private float health;

    private bool isAlive = true;

    private void Start()
    {
        if (config == null)
        {
            Debug.LogError("This Enemy has no EnemyConfig attached");
            return;
        }
        if (config.health <= 0)
            Debug.LogWarning("This Enemys initial health is zero or less");
        
        SetHealth(config.health);

        SplineAnimate splineAnimate = GetComponent<SplineAnimate>();
        splineAnimate.AnimationMethod = SplineAnimate.Method.Speed;
        splineAnimate.MaxSpeed = config.movementSpeed;
    }

    private void SetHealth(float newHealth)
    {
        health = newHealth;
        if(health <= 0)
        {
            isAlive = false;
            Die();
        }
    }

    public void ReduceHealth(float damage)
    {
        SetHealth(health - damage);
    }

    private void Die()
    {
        if(config.drops.Count > 0)
        {
            Inventory inventory = FindObjectOfType<Inventory>();
            foreach(var drop in config.drops)
            {
                switch(drop.Key)
                {
                    case Enums.DropTypes.Money:
                        inventory.Money += drop.Value;
                        break;
                    case Enums.DropTypes.Jewels:
                        inventory.Jewels += drop.Value;
                        break;
                    default: 
                        break;
                }
            }
        }
        Destroy(gameObject);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(isAlive)
            ReduceHealth(1);
    }

    public void OnReachedEnd()
    {
        Destroy(gameObject);
    }
}
