using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TapTD.InventoryManagement;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using TapTD.Towers;
using AYellowpaper.SerializedCollections;

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
        [SerializeField]
        private SerializedDictionary<Enums.ResourceTypes, TextMeshProUGUI> resourceAmountTexts;

        private void Start()
        {
            UpdateMoney();
            foreach (Enums.ResourceTypes resourceType in resourceAmountTexts.Keys)
                UpdateResourceAmount(resourceType);
        }

        public void UpdateMoney()
        {
            moneyValueText.text = GameManager.Instance.Inventory.Money.ToString();
        }

        public void UpdateResourceAmount(Enums.ResourceTypes resourceType)
        {
            if (!resourceAmountTexts.ContainsKey(resourceType))
                return;

            resourceAmountTexts[resourceType].text = GameManager.Instance.Inventory.Resources[resourceType].ToString();
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

        public void AddResourceAmountText(Enums.ResourceTypes resourceType, TextMeshProUGUI text)
        {
            if (resourceAmountTexts.ContainsKey(resourceType))
                return;
            resourceAmountTexts.Add(resourceType, text);
        }
    }
}
