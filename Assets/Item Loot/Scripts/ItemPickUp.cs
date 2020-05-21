using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public ItemPickUps_SO itemDefinition;
    public PlayerStats playerStats;
    PlayerInventory playerInventory;
    GameObject foundStats;
    public ItemPickUp()
    {
        playerInventory = PlayerInventory.instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        foundStats = GameObject.FindGameObjectWithTag("Player");
        playerStats = foundStats.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StoreItem()
    {
        //playerInventory.StoreItem();
    }
    public void UseItem()
    {
        switch(itemDefinition.itemType)
        {
            case ItemTypeDefinitions.HEALTH:
                //playerStats.
                break;
            case ItemTypeDefinitions.WEAPON:
                //playerStats.ChangeWeapon();
                break;
            case ItemTypeDefinitions.ARMOR:
                //playerStats.ChangeArmor();
                break;
        }
    }
}
