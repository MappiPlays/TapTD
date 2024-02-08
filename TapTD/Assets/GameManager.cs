using UnityEngine;
using TapTD;
using TapTD.UI;
using TapTD.InventoryManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

    [SerializeField]
    public UIManager UIManager;
    [SerializeField]
    public Inventory Inventory;
    [SerializeField]
    public ResourcesConfig ResourcesConfig;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }
}
