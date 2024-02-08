using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace TapTD.InventoryManagement
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField]
        private float money;
        public float Money
        {
            get { return money; }
            set
            { 
                money = value; 
                GameManager.Instance.UIManager.UpdateMoney();
            }
        }
        public float Jewels;
        public SerializedDictionary<Enums.ResourceTypes, int> Resources;
    }
}
