using Unity.VisualScripting;
using UnityEngine;

public abstract class AbsEnemyFactory : MonoBehaviour
{
    public abstract IEnemy CreateEnemy();
}

public interface IEnemy
{
    void Attack();
}










