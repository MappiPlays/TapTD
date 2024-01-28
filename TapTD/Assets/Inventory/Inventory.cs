using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace TapTD.InventoryManagement
{
    public class Inventory : MonoBehaviour
    {
        public float Money;
        public float Jewels;
        public SerializedDictionary<Enums.ResourceTypes, int> Resources;
    }
}
