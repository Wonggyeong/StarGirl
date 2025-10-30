using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField] private PlantFactory plantFactory = null;

    // �Ĺ��� ���ڸ����� ������ 3���� �ٽ� ����, �����̴� ������ , ���� ���߿���

    public PlantFactory plant { get; set; }

    private void Awake()
    {
        plant = plantFactory;

        if (plant == null)
            Debug.Log("plant is nullllllllll");
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //plant.Ray();
        plant.PlantToPlayerDistance();
    }
}
