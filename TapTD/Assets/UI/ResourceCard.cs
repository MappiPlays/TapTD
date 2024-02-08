using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TapTD.UI
{
    public class ResourceCard : MonoBehaviour
    {
        [SerializeField]
        private Image image;
        public TextMeshProUGUI AmountText;

        [Header("Resource")]
        public Enums.ResourceTypes ResourceType;

        private void Start()
        {
            image.sprite = GameManager.Instance.ResourcesConfig.Resources[ResourceType];
        }
    }
}