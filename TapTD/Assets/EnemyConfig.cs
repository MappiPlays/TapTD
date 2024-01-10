using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyConfig", fileName = "NewEnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    public GameObject EnemyPrefab;
    public float health;
    public float movementSpeed;
    public SerializedDictionary<Enums.DropTypes, float> drops;
}
