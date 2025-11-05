using TMPro;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;


public class PlantFactory : AbsEnemyFactory
{
    [SerializeField] private GameObject m_OriginPlantPrefab; // 원본 프리팹
    [SerializeField] private Transform spawnPoint;           // 리스폰 위치

    public override IEnemy CreateEnemy()
    {
        GameObject newPlant = Instantiate(m_OriginPlantPrefab, spawnPoint.position, Quaternion.identity);
        var plantScript = newPlant.GetComponent<EnemyPlant>();

        return plantScript;
    }

    public void OffOriginPlantPrefab()
    {
        m_OriginPlantPrefab.SetActive(false);
    }
}
