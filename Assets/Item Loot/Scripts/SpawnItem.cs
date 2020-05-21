using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour, ISpawns
{
    public ItemPickUps_SO[] itemDefinitions;

    private int whichToSpawn = 0;
    private int totalSpawnWeight = 0;
    private int chosen = 0;

    public Rigidbody itemSpawned { get; set; }
    public ItemPickUp itemType { get; set; }
    public Renderer itemMaterial { get; set; }

    void Start()
    {
        foreach (ItemPickUps_SO i in itemDefinitions)
        {
            totalSpawnWeight += i.spawnChanceWeight;
        }
    }

    public void CreateSpawn()
    {
        //Spawn with weighted possibilities
        chosen = Random.Range(0, totalSpawnWeight);

        foreach (ItemPickUps_SO i in itemDefinitions)
        {
            whichToSpawn += i.spawnChanceWeight;
            if (whichToSpawn >= chosen)
            {
                itemSpawned = Instantiate(i.itemSpawnObject, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

                itemMaterial = itemSpawned.GetComponent<Renderer>();
                itemMaterial.material = i.itemMaterial;

                itemType = itemSpawned.GetComponent<ItemPickUp>();
                itemType.itemDefinition = i;
                break;
            }
        }
    }
}
