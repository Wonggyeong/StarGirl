using TMPro;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using static EnemyPlant;

public class EnemyPlant : MonoBehaviour, IEnemy
{
    [SerializeField] private Animator m_Ani;
    [SerializeField] private Rigidbody2D m_Rigid;
    [SerializeField] private SpriteRenderer m_sprite;

    [SerializeField] private PlayerMove m_PlayerMove; // player와의 거리를 구하기 위해
    private EnemyType m_EnemyType = EnemyType.Plant;

    public void Attack()
    {
        Debug.Log("풀 몬스터 공격!");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CommonFuction.SetBool(m_Ani, "isAttack", true);
            Debug.Log("충돌충돌충돌");
        }
    }

    public void PlayerApprochSensor() // 다른 몬스터에게도 있어야함 다르게? 같이?
    {
        var playerPos = m_PlayerMove.m_Rigid.position;
        var monsterPos = m_Rigid.position;

        float distance = Vector2.Distance(playerPos, monsterPos);
        //Debug.Log($"거리 : {distance}");

        if (playerPos.x < monsterPos.x)
        {
            Debug.Log("플레이어가 왼쪽에 있음");
            m_sprite.flipX = false;
        }
        else
        {
            Debug.Log("플레이어가 오른쪽에 있음");
            m_sprite.flipX = true;
        }
    }

    public void OnDamaged()
    {
        m_sprite.color = new Color(1, 1, 1, 0.4f);
        //sprite Flip y
        m_sprite.flipY = true;
        //collider Disable

        Invoke("DeActive", 5);
    }

    private void DeActive()
    {
        this.gameObject.SetActive(false);
    }

}

public class PlantFactory : AbsEnemyFactory
{
    [SerializeField] private GameObject m_OriginPlantPrefab; // 원본 프리팹
    [SerializeField] private Transform spawnPoint;           // 리스폰 위치

    public override IEnemy CreateEnemy()
    {
        GameObject newPlant = Instantiate(m_OriginPlantPrefab, spawnPoint.position, Quaternion.identity);
        //var plantScript = newPlant.GetComponent<EnemyPlant>();
        var t = new EnemyPlant();
        return t;
    }
}
