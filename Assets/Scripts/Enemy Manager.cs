using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> aliveEnemyList;
    public int enemyPerWave;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        AddAliveEnemiesToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddAliveEnemiesToList()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        aliveEnemyList.AddRange(enemies);
    }

}
