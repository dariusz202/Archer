using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class EnemySpawnManager : MonoBehaviour
{
    private float positionx;
    private float positionz;
   // public RangeEnemy rangeEnemy;
   // public MeleeEnemy meleeEnemy;
    public GameObject[] enemyList = new GameObject[2];
    private int rangeEnemyCount;
    private int meleeEnemyCount;
    public int enemyCount;
    public int waveNumber = 3;
    [SerializeField] float rangex1;
    [SerializeField] float rangex2;
    [SerializeField] float rangez;


    void Start()
    {
        //Instantiate(rangeEnemy, RandomPosition(), rangeEnemy.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        rangeEnemyCount = FindObjectsOfType<RangeEnemy>().Length;
        meleeEnemyCount = FindObjectsOfType<MeleeEnemy>().Length;
        enemyCount = rangeEnemyCount + meleeEnemyCount;
        if(enemyCount == 0)
        {
            spawnEnemy(waveNumber);
            waveNumber++;
        }

    }
    Vector3 RandomPosition()
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
    void spawnEnemy(int waveNumber)
    {
        for(int i =0; i< waveNumber; i++)
        {
            int randomIndex = Random.Range(0, enemyList.Length);
            Instantiate(enemyList[randomIndex], RandomPosition(), transform.rotation);
        }
    }

}
