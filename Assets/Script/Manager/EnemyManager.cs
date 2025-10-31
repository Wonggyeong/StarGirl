using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField] private PlantFactory plantFactory = null;
    [SerializeField] private int m_PlantCount = 3;

    List<AbsEnemyFactory> enemyList = new();

    // 식물은 제자리에서 죽으면 3초후 다시 생김, 달팽이는 땅에서 , 벌은 공중에서


    private void Awake()
    {
        if (plantFactory == null)
            Debug.Log("plant is nullllllllll");
    }

    private void Start()
    {
        for (int i = 0; i < m_PlantCount; i++)
        {
            plantFactory.CreateEnemy();
        }
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //plant.PlayerApprochSensor();

        
    }
}
