using UnityEngine;
using UnityEngine.UI;
using TapTD.Towers;
using TMPro;

namespace TapTD.UI
{
    public class TowerCard : MonoBehaviour
    {
        [SerializeField]
        private GameObject towerPrefab;
        [SerializeField]
        private Image image;
        [SerializeField]
        private TextMeshProUGUI priceText;

        private int price;

        private void Start()
        {
            if (towerPrefab == null)
            {
                Debug.LogError("There is no TowerPrefab on this TowerCard");
                return;
            }

            price = towerPrefab.GetComponent<Tower>().Config.price;
            priceText.text = price.ToString();
        }

        public void OnButtonClicked()
        {
            if (GameManager.Instance.Inventory.Money < price)
                return;

            Tower newTower = Instantiate(towerPrefab).GetComponent<Tower>();
            GameManager.Instance.UIManager.LoadTowerPlacementUI(newTower);
        }
    }
}