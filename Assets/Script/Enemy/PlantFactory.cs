using TMPro;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using static EnemyPlant;

public class EnemyPlant : MonoBehaviour, IEnemy
{
    [SerializeField] private Animator m_Ani;
    [SerializeField] private Rigidbody2D m_Rigid;
    [SerializeField] private SpriteRenderer m_sprite;

    [SerializeField] private PlayerMove m_PlayerMove; // player���� �Ÿ��� ���ϱ� ����
    private EnemyType m_EnemyType = EnemyType.Plant;

    public void Attack()
    {
        Debug.Log("Ǯ ���� ����!");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CommonFuction.SetBool(m_Ani, "isAttack", true);
            Debug.Log("�浹�浹�浹");
        }
    }

    public void PlayerApprochSensor() // �ٸ� ���Ϳ��Ե� �־���� �ٸ���? ����?
    {
        var playerPos = m_PlayerMove.m_Rigid.position;
        var monsterPos = m_Rigid.position;

        float distance = Vector2.Distance(playerPos, monsterPos);
        //Debug.Log($"�Ÿ� : {distance}");

        if (playerPos.x < monsterPos.x)
        {
            Debug.Log("�÷��̾ ���ʿ� ����");
            m_sprite.flipX = false;
        }
        else
        {
            Debug.Log("�÷��̾ �����ʿ� ����");
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
    [SerializeField] private GameObject m_OriginPlantPrefab; // ���� ������
    [SerializeField] private Transform spawnPoint;           // ������ ��ġ

    public override IEnemy CreateEnemy()
    {
        GameObject newPlant = Instantiate(m_OriginPlantPrefab, spawnPoint.position, Quaternion.identity);
        //var plantScript = newPlant.GetComponent<EnemyPlant>();
        var t = new EnemyPlant();
        return t;
    }
}
