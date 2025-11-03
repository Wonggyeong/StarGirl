using Unity.VisualScripting;
using UnityEngine;

public class EnemyPlant : MonoBehaviour, IEnemy
{
    [SerializeField] private Animator m_Ani;
    [SerializeField] private Rigidbody2D m_Rigid;
    [SerializeField] private SpriteRenderer m_sprite;

    [SerializeField] private PlayerMove m_PlayerMove; // player와의 거리를 구하기 위해

    //private EnemyType m_EnemyType = EnemyType.Plant;
    private bool m_isAttack = false;

    private void FixedUpdate()
    {
        PlayerApprochSensor(); // player 감지
    }

    private void Update()
    {
        
    }

    public void OnAttack()
    {
        Debug.Log("풀 몬스터 공격!");
    }

    public void PlayerApprochSensor() // 다른 몬스터에게도 있어야함 다르게? 같이?
    {
        var playerPos = m_PlayerMove.m_Rigid.position;
        var monsterPos = m_Rigid.position;

        if (playerPos.x < monsterPos.x)
            m_sprite.flipX = false; // 플레이어가 왼쪽
        else
            m_sprite.flipX = true; // 플레이어가 오른쪽

        float distance = Vector2.Distance(playerPos, monsterPos);
        //Debug.Log($"거리 : {distance}"); // 3 이하일 때 공격 모션 , 2.3이하일 때 공격 유효타

        PlantAttackAni(distance);

        if (distance <= 2.4f)
            OnAttack();
    }

    private void PlantAttackAni(float distance)
    {
        if (distance <= 3f)
            m_isAttack = true;
        else
            m_isAttack = false;

        CommonFuction.SetBool(m_Ani, "isAttack", m_isAttack);
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
