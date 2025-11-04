using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    // TODO : NULL체크
    // Die, 데미지 받았을 때, 무한점프 막기,
     public Rigidbody2D m_Rigid;
    [SerializeField] private Vector2 m_Position;

    [SerializeField] private SpriteRenderer m_SpriteRenderer;
    [SerializeField] private Animator m_Animator;

    public float m_MaxSpeed = 0f;
    public float m_JumpPower = 0f;

    // FixedUpDate() 
    public void Walk() 
    {
        float h = Input.GetAxisRaw("Horizontal"); 
        m_Rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse); // left는 -1라서 거꾸로 감

        if (m_Rigid.linearVelocity.x > m_MaxSpeed)        // right
            m_Rigid.linearVelocity = new Vector2(m_MaxSpeed, m_Rigid.linearVelocity.y);
        else if (m_Rigid.linearVelocity.x < -m_MaxSpeed)  // left
            m_Rigid.linearVelocity = new Vector2(-m_MaxSpeed, m_Rigid.linearVelocity.y);
    }

    public void LandingPlatform()
    {
        // Landing platform
        if (m_Rigid.linearVelocity.y < 0)
        {
            RaycastHit2D rayHit = Physics2D.Raycast(m_Rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
            //Debug.Log(rayHit.distance); 공중높이
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 1f)
                {
                    CommonFuction.SetBool(m_Animator, "isJump", false);
                }
            }
        }
    }

    #region Update()

    public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            m_Rigid.AddForce(Vector2.up * m_JumpPower, ForceMode2D.Impulse);
            // 애니메이터
            CommonFuction.SetBool(m_Animator, "isJump", true);
        }
    }

    public void WalkAni()
    {
        if (Mathf.Abs(m_Rigid.linearVelocity.x) < 0.3) // math 절댓값
            CommonFuction.SetBool(m_Animator, "isWalk", false);
        else
            CommonFuction.SetBool(m_Animator, "isWalk", true);
    }

    public void StopWalkSpeed()
    {
        if (Input.GetButtonUp("Horizontal")) //rigid.linearVelocity.normalized 현재 이동 방향
        {
            m_Rigid.linearVelocity = new Vector2(m_Rigid.linearVelocity.normalized.x * 0.5f, m_Rigid.linearVelocity.y);
        }
    }

    public void DirectionSprite()
    {
        if (Input.GetButton("Horizontal"))
            m_SpriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
    }

    #endregion


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {   // Attack
            var enemyPosition = collision.transform.position;
            if (m_Rigid.linearVelocity.y < 0 && this.transform.position.y > enemyPosition.y)
            {
                OnAttack(collision.transform);
            }
        }
    }

    private void OnAttack(Transform enemy)
    {
        // Enemy Die
        EnemyPlant plant = enemy.GetComponent<EnemyPlant>();
        plant.OnDamaged();
    }

    // InputSystem
    public void OnWalk(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("플레이어가 걷는다");
        }

        if (context.canceled)
        {
            Debug.Log("멈췄다");
        }

    }
    
}
