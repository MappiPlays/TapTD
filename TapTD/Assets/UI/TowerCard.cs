using UnityEngine;
using UnityEngine.UI;
using TapTD.Towers;
using TMPro;

namespace TapTD.UI
{
    public class TowerCard : MonoBehaviour
    {
        [SerializeField]
        private Image image;
        [SerializeField]
        private TextMeshProUGUI priceText;
        
        [Header("Tower")]
        [SerializeField]
        private GameObject towerPrefab;

        private int price;

        private void Start()
        {
            if (towerPrefab == null)
            {
                Debug.LogError("There is no TowerPrefab on this TowerCard");
                return;
            }
            TowerConfig towerConfig = towerPrefab.GetComponent<Tower>().Config;
            price = towerConfig.price;
            priceText.text = price.ToString();
            image.sprite = towerConfig.sprite;
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