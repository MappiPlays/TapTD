using TMPro;
using UnityEngine;
using TapTD.InventoryManagement;

namespace TapTD.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI moneyValueText;

        private Inventory inventory;

        private void Awake()
        {
            inventory = FindObjectOfType<Inventory>();
        }

        private void Update()
        {
            moneyValueText.text = inventory.Money.ToString();
        }
    }
}
