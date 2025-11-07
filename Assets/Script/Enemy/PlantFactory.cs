using TMPro;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;


public class PlantFactory : AbsEnemyFactory
{
    [SerializeField] private GameObject m_OriginPlantPrefab; // 원본 프리팹
    //[SerializeField] private Transform m_spawnPoint;           // 리스폰 위치

    [SerializeField] private Vector2 xRange = new Vector2(-5f, 5f);
    public override IEnemy CreateEnemy() 
    {
        float randX = Random.Range(xRange.x, xRange.y); // 몬스터끼리 안겹치게 하고 싶은데
        Vector3 spawnPos = new Vector3(randX, -0.6f, 0f);

        GameObject newPlant = Instantiate(m_OriginPlantPrefab, spawnPos, Quaternion.identity);
        var plantScript = newPlant.GetComponent<EnemyPlant>();

        return plantScript;
    }

    public void OffOriginPlantPrefab()
    {
        m_OriginPlantPrefab.SetActive(false);
    }
}
