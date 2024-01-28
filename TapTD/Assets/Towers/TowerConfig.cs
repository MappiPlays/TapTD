using UnityEngine;

namespace TapTD.Towers
{
    [CreateAssetMenu(menuName = "TowerConfig", fileName = "newTowerConfig")]
    public class TowerConfig : ScriptableObject
    {
        public Sprite sprite;
        public GameObject bulletPrefab;
        public int price;
        public float damage;
        public float attackDelay;
        public float range;
    }
}