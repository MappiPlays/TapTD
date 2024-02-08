using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace TapTD.InventoryManagement
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField]
        private int money;
        public int Money
        {
            get { return money; }
            set
            { 
                money = value; 
                GameManager.Instance.UIManager.UpdateMoney();
            }
        }
        public int Jewels;
        public SerializedDictionary<Enums.ResourceTypes, int> Resources;

        public void AddResource(Enums.ResourceTypes resourceType, int amount = 1)
        {
            if (!Resources.ContainsKey(resourceType))
                return;

            Resources[resourceType] += amount;
            GameManager.Instance.UIManager.UpdateResourceAmount(resourceType);
        }
    }
}
