using UnityEngine;
using UnityEngine.UI;

namespace TapTD.Towers
{
    public class TowerPlacement : MonoBehaviour
    {
        [SerializeField] private Button buttonCancel;
        [SerializeField] private Button buttonAccept;

        private Tower tower;

        public void SetTower(Tower newTower)
        {
            tower = newTower;
            buttonCancel.onClick.RemoveAllListeners();
            buttonAccept.onClick.RemoveAllListeners();
            buttonCancel.onClick.AddListener(Cancel);
            buttonAccept.onClick.AddListener(Accept);
        }

        private void Cancel()
        {
            Destroy(tower.gameObject);
            Destroy(gameObject);
        }

        private void Accept()
        {
            if (GameManager.Instance.Inventory.Money < tower.Config.price)
                return;

            if (tower.CanBePlaced)
            {
                GameManager.Instance.Inventory.Money -= tower.Config.price;
                tower.SetState(Enums.TowerStates.Placed);
                Destroy(gameObject);
            }
        }
    }
}