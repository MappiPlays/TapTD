using UnityEngine;
using UnityEngine.UI;

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
        if (tower.CanBePlaced)
        {
            tower.SetState(Enums.TowerStates.Placed);
            Destroy(gameObject);
        }
    }
}
