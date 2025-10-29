using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D m_Rigid;
    [SerializeField] private Vector2 m_Position;

    public float m_MaxSpeed = 0f;
    public float m_JumpPower = 0f;

    // InputSystem 적용해보기? 애니 전환이 일어나는 부분
    public void Walk() 
    {
        float h = Input.GetAxisRaw("Horizontal"); 
        m_Rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse); // left는 -1라서 거꾸로 감

        if (m_Rigid.linearVelocity.x > m_MaxSpeed)        // right
            m_Rigid.linearVelocity = new Vector2(m_MaxSpeed, m_Rigid.linearVelocity.y);
        else if (m_Rigid.linearVelocity.x < -m_MaxSpeed)  // left
            m_Rigid.linearVelocity = new Vector2(-m_MaxSpeed, m_Rigid.linearVelocity.y);

    }

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
