using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyPlant : MonoBehaviour, IEnemy
{
    // TODO : 공격, 죽음, 
    [SerializeField] private Animator m_Ani;
    [SerializeField] private Rigidbody2D m_Rigid;
    [SerializeField] private BoxCollider2D m_Collider;
    [SerializeField] private SpriteRenderer m_Sprite;

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
            m_Sprite.flipX = false; // 플레이어가 왼쪽
        else
            m_Sprite.flipX = true; // 플레이어가 오른쪽

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
        CommonFuction.SetBool(m_Ani, "isDead", false);
    }

    public void OnDamaged()
    {
        bool activeState = this.gameObject.activeSelf;
        Debug.Log($"OnDamaged 진입 후 activeState : {activeState}");

        m_Sprite.color = new Color(1, 1, 1, 0.4f);

        m_Collider.enabled = false;
        // ani
        CommonFuction.SetBool(m_Ani, "isDead", true);
    }

    private void DeActive() // ani Event로 사용중
    {
        this.gameObject.SetActive(false);

        bool activeState = this.gameObject.activeSelf;
        Debug.Log($"DeActive 진입 후 activeState : {activeState}");
    }

    public void Respawn()
    {
        // 상태 초기화
        m_Collider.enabled = true;
        m_Sprite.color = Color.white;
        m_Sprite.flipY = false;

        CommonFuction.SetBool(m_Ani, "isDead", false);

        gameObject.SetActive(true);
    }
}
