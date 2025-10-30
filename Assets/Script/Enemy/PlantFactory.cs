using UnityEngine;
using static EPlant;

public class EPlant : IEnemy
{
    public void Attack()
    {
        Debug.Log("풀 몬스터 공격!");
    }
}

public class PlantFactory : AbsEnemyFactory
{
    [SerializeField] private Animator m_Animator;
    [SerializeField] private Rigidbody2D m_Rigid;

    [SerializeField] private PlayerMove m_PlayerMove; // player와의 거리를 구하기 위해

    public override IEnemy CreateEnemy()
    {
        EPlant plant = new EPlant();
        return plant;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CommonFuction.SetBool(m_Animator, "isAttack", true);
            Debug.Log("충돌충돌충돌");

        }
    }

    public void Ray()
    {
        Debug.DrawRay(new Vector2(m_Rigid.position.x, m_Rigid.position.y), Vector3.left, new Color(0, 1, 0));
    }

    public void PlantToPlayerDistance()
    {
        var playerPos = m_PlayerMove.m_Rigid.position;
        var monsterPos = m_Rigid.position;

        float distance = Vector2.Distance(playerPos, monsterPos);
        Debug.Log($"거리 : {distance}");

        if (playerPos.x > monsterPos.x)
        {
            Debug.Log("플레이어가 오른쪽에 있음");
        }
        

        // 
    }
}
