using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    #region Variable Declaration
    public static PlayerInventory instance;

    public PlayerStats charStats;
    GameObject foundStats;

    public Image[] hotBarDisplayHolders = new Image[4];
    public GameObject InventoryDisplayHolder;
    public Image[] inventoryDisplaySlots = new Image[30];

    int inventoryItemCap = 20;
    int idCount = 1;
    bool addedItem = true;

    public Dictionary<int, InventoryEntry> itemsInInventory = new Dictionary<int, InventoryEntry>();
    public InventoryEntry itemEntry;
    #endregion

    #region Initializations
    void Start()
    {
        instance = this;
        itemEntry = new InventoryEntry(0, null, null);
        itemsInInventory.Clear();

        inventoryDisplaySlots = InventoryDisplayHolder.GetComponentsInChildren<Image>();

        foundStats = GameObject.FindGameObjectWithTag("Player");
        charStats = foundStats.GetComponent<PlayerStats>();
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StoreItem(ItemPickUp itemToStore)
    {

    }
    void TryPickUp()
    {

    }
    bool AddItemToInv(bool finishedAdding)
    {
        return true;
    }
    private void AddItemToHotBar(InventoryEntry itemForHotBar)
    {
        
    }
    void DisplayInventory()
    {

    }
    void FillInventoryDisplay()
    {

    }
    public void TriggerItemUse(int itemToUseID)
    {

    }
}
