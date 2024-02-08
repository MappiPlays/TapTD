using UnityEngine;
using UnityEngine.UI;
using TapTD.UI;
using TMPro;

public class InventoryView : MonoBehaviour
{
    [SerializeField]
    private GameObject ResourceScrollViewContent;
    [SerializeField]
    private GameObject ResourceCardPrefab;

    private void Start()
    {
        FillResourceView();
        gameObject.SetActive(false);
    }

    private void FillResourceView()
    {
        GameObject newCard;
        ResourceCard resourceCard;
        UIManager uiManager = GameManager.Instance.UIManager;
        foreach (var item in GameManager.Instance.ResourcesConfig.Resources)
        {
            newCard = Instantiate(ResourceCardPrefab, ResourceScrollViewContent.transform);
            resourceCard = newCard.GetComponent<ResourceCard>();
            resourceCard.ResourceType = item.Key;
            uiManager.AddResourceAmountText(item.Key, resourceCard.AmountText);
        }
    }
}
