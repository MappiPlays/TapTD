using AYellowpaper.SerializedCollections;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyConfig", fileName = "NewEnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    public Sprite sprite;
    public float health;
    public float movementSpeed;
    [Header("Drops")]
    public SerializedDictionary<Enums.DropTypes, int> dropAmounts;
    public Enums.ResourceTypes dropResource;
}
