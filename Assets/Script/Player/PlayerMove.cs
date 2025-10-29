using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    // TODO : NULLüũ
    // Die, ������ �޾��� ��, �������� ����,
    [SerializeField] private Rigidbody2D m_Rigid;
    [SerializeField] private Vector2 m_Position;

    [SerializeField] private SpriteRenderer m_SpriteRenderer;
    [SerializeField] private Animator m_Animator;

    public float m_MaxSpeed = 0f;
    public float m_JumpPower = 0f;

    // FixedUpDate() 
    public void Walk() 
    {
        float h = Input.GetAxisRaw("Horizontal"); 
        m_Rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse); // left�� -1�� �Ųٷ� ��

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
            Debug.Log(rayHit.distance);
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
            // �ִϸ�����
            CommonFuction.SetBool(m_Animator, "isJump", true);
        }
    }

    public void WalkAni()
    {
        if (Mathf.Abs(m_Rigid.linearVelocity.x) < 0.3) // math ����
            CommonFuction.SetBool(m_Animator, "isWalk", false);
        else
            CommonFuction.SetBool(m_Animator, "isWalk", true);
    }

    public void StopWalkSpeed()
    {
        if (Input.GetButtonUp("Horizontal")) //rigid.linearVelocity.normalized ���� �̵� ����
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

    // InputSystem
    public void OnWalk(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("�÷��̾ �ȴ´�");
        }

        if (context.canceled)
        {
            Debug.Log("�����");
        }

    }
    
}
