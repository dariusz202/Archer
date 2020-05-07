using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class EnemySpawnManager : MonoBehaviour
{
    private float positionx;
    private float positionz;
    public GameObject[] enemyTypeList = new GameObject[2];
    public List<GameObject> enemys;
    private int rangeEnemyCount;
    private int meleeEnemyCount;
    public int amountEnemys;
    public int enemyCount = 5;
    public int waveNumber = 1;
    [SerializeField] float rangex1;
    [SerializeField] float rangex2;
    [SerializeField] float rangez;

    void Start()
    {
        enemys = new List<GameObject>();
        for (int i = 0; i < amountEnemys; i++)
        {
            int randomIndex = Random.Range(0, enemyTypeList.Length);
            GameObject obj = Instantiate(enemyTypeList[randomIndex], RandomPosition(), transform.rotation);
            obj.SetActive(false);
            enemys.Add(obj);
        }
    }

    void Update()
    {
        rangeEnemyCount = FindObjectsOfType<RangeEnemy>().Length;
        meleeEnemyCount = FindObjectsOfType<MeleeEnemy>().Length;
        enemyCount = rangeEnemyCount + meleeEnemyCount;
        if(enemyCount == 0 && waveNumber <= 5)
        {
            SpawnEnemy(waveNumber);
            waveNumber++;
        }

    }
    public Vector3 RandomPosition()
    {
        float x1 = Random.Range(rangex1, rangex2);
        float x2 = Random.Range(-rangex1, -rangex2);
        if (Random.value < 0.5f)
            positionx = x1;
        else
            positionx = x2;
        positionz = Random.Range(rangez, -rangez);

        Vector3 randomPosition = new Vector3(positionx, 1.5f, positionz);
        return randomPosition;
    }

    void SpawnEnemy(int waveNumber)
    {
        for (int i = 0; i < waveNumber; i++)
        {
            GetEnemy().SetActive(true);
        }

    }

    public GameObject GetEnemy()
    {
        for (int i = 0; i < enemys.Count; i++)
        {
            if (!enemys[i].activeInHierarchy)
            {
                return enemys[i];
            }
        }
        return null;
    }

}
