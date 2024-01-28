using UnityEngine;

namespace TapTD.Towers
{
    [CreateAssetMenu(menuName = "TowerConfig", fileName = "newTowerConfig")]
    public class TowerConfig : ScriptableObject
    {
        public GameObject bulletPrefab;
        public float damage;
        public float attackDelay;
        public int price;
    }
}