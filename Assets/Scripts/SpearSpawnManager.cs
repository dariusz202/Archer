using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearSpawnManager : MonoBehaviour
{
    public static SpearSpawnManager SharedInstance;
    public List<GameObject> spears;
    public GameObject spear;
    [SerializeField] int amountSpears = 5;

    private void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        spears = new List<GameObject>();
        for (int i = 0; i < amountSpears; i++)
        {
            GameObject obj = Instantiate(spear);
            obj.SetActive(false);
            spears.Add(obj);
            obj.transform.SetParent(this.transform);
        }

    }
    public GameObject GetSpear()
    {
        for (int i = 0; i < spears.Count; i++)
        {
            if (!spears[i].activeInHierarchy)
            {
                return spears[i];
            }
        }
        return null;
    }
}
