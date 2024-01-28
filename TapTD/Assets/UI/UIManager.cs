using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TapTD.InventoryManagement;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace TapTD.UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField]
        private GameObject towerPlacementUIPrefab;

        [Header("UI Elements")]
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

        public void LoadTowerPlacementUI(Tower tower)
        {
            GameObject towerPlacementUI = Instantiate(towerPlacementUIPrefab, transform);
            towerPlacementUI.GetComponent<TowerPlacement>().SetTower(tower);
        }

        public bool IsScreenPositionOnUI(Vector2 screenPosition)
        {
            GraphicRaycaster raycaster = GetComponent<GraphicRaycaster>();
            PointerEventData pointerEventData = new(EventSystem.current);
            pointerEventData.position = screenPosition;
            List<RaycastResult> results = new();
            raycaster.Raycast(pointerEventData, results);
            if (results.Count > 0)
                return true;
            return false;
        }
    }
}
