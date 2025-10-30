using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField] private PlantFactory plantFactory = null;

    // 식물은 제자리에서 죽으면 3초후 다시 생김, 달팽이는 땅에서 , 벌은 공중에서

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
