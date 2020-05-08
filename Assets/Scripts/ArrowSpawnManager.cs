using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawnManager : MonoBehaviour
{
    public static ArrowSpawnManager SharedInstance;
    public List<GameObject> arrows;
    public GameObject arrow;
    [SerializeField] int amountArrows = 5;

    private void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        arrows = new List<GameObject>();
        for(int i = 0; i < amountArrows; i++)
        {
            GameObject obj = Instantiate(arrow);
            obj.SetActive(false);
            arrows.Add(obj);
            obj.transform.SetParent(this.transform);
        }

    }
    public GameObject GetArrow()
    {
        for(int i = 0; i < arrows.Count; i++)
        {
            if(!arrows[i].activeInHierarchy)
            {
                return arrows[i];
            }
        }
        return null;
    }
}
