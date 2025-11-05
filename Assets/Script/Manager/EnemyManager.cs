using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField] private PlantFactory plantFactory = null;
    [SerializeField] private int m_PlantCount = 3;

    public List<IEnemy> enemyList = new();
    //public List<EnemyPlant> plant = new();

    // 식물은 제자리에서 죽으면 3초후 다시 생김, 달팽이는 땅에서 , 벌은 공중에서
    // 지형 몬스터는 내가 맵에서 위치를 지정해주는 것이 아니라 알아서 자리 잡으면 좋겠음
    // 몬스터의 죽음도 여기서 관리?

    private void Awake()
    {
        if (plantFactory == null)
            Debug.Log("plant is nullllllllll");
    }

    private void Start()
    {
        enemyList.Clear();

        for (int i = 0; i < m_PlantCount; i++)
        {
            var enemy = plantFactory.CreateEnemy();
            enemyList.Add(enemy);
        }

        plantFactory.OffOriginPlantPrefab();
    }

    private void Update()
    {
        foreach (var enemy in enemyList)
        {
            if (!enemy.gameObject.activeSelf)
            {
                var sec = Random.Range(3, 7);
                StartCoroutine(RespwanEnemy(enemy, sec));
            }
        }
    }

    private IEnumerator RespwanEnemy(IEnemy enemy, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        enemy.Respawn();
    }




}
