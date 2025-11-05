using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public abstract class AbsEnemyFactory : MonoBehaviour
{
    public abstract IEnemy CreateEnemy();
}

public interface IEnemy
{
    public GameObject gameObject { get;} // 몬스터 오브젝트 활성화 상태 알기 위함
    void OnAttack();

    void OnDamaged();

    void Respawn();

    void PlayerApprochSensor();

    
}










