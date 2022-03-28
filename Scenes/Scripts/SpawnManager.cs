using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject stripPrefab;
    public GameObject catcherPrefab;
    private float m_SpawnTime = 2.0f;
    private float m_CatcherSpawnTime = 2.0f;
    private float m_StripSpawnTime = 1.0f;
 
   

    GameObject leftWall, rightWall;
    // Start is called before the first frame update
    void Start()
    {
        leftWall = GameObject.Find("LeftWall");
        rightWall = GameObject.Find("RightWall");

      
        InvokeRepeating(nameof(SpawnEvader), 0, m_SpawnTime);
        InvokeRepeating(nameof(SpawnCatcher), 1.0f, m_CatcherSpawnTime);
        InvokeRepeating(nameof(SpawnStrip), 0, m_StripSpawnTime);
        
    }

    // Update is called once per frame
    private void SpawnEnemy(EnemyController.EnemyType enemyType)
    {
        Vector3 spawnPosition = new Vector3(
            getRandomRange(),
            enemyPrefab.transform.position.y,
            enemyPrefab.transform.position.z
            );

        if (enemyType == EnemyController.EnemyType.Catcher)
        {
            Instantiate(
            catcherPrefab,
            spawnPosition,
            catcherPrefab.transform.rotation
            );
        }
        else
        {
            Instantiate(
            enemyPrefab,
            spawnPosition,
            enemyPrefab.transform.rotation
            );
        }
    }
    private void SpawnStrip()
    {
        Instantiate(stripPrefab);
    }
    
    private float getRandomRange() 
    {
        float randomRange= Random.Range(
                            leftWall.transform.position.x + leftWall.transform.localScale.x * 3 / 2,
                            rightWall.transform.position.x - rightWall.transform.localScale.x * 3 / 2
                        );

        return randomRange;

    }
    private void SpawnEvader() 
    {
        SpawnEnemy(EnemyController.EnemyType.Evader);
    }
    private void SpawnCatcher() 
    {
        SpawnEnemy(EnemyController.EnemyType.Catcher);
    }




}
