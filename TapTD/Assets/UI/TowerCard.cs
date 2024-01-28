using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerCard : MonoBehaviour
{
    [SerializeField]
    private GameObject TowerPrefab;

    public void OnButtonClicked()
    {
        Tower newTower = Instantiate(TowerPrefab).GetComponent<Tower>();
        GameManager.Instance.UIManager.LoadTowerPlacementUI(newTower);
    }
}
