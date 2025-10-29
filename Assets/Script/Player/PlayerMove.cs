using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D m_Rigid;
    [SerializeField] private Vector2 m_Position;

    public float m_MaxSpeed = 0f;
    public float m_JumpPower = 0f;

    // InputSystem �����غ���? �ִ� ��ȯ�� �Ͼ�� �κ�
    public void Walk() 
    {
        float h = Input.GetAxisRaw("Horizontal"); 
        m_Rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse); // left�� -1�� �Ųٷ� ��

        if (m_Rigid.linearVelocity.x > m_MaxSpeed)        // right
            m_Rigid.linearVelocity = new Vector2(m_MaxSpeed, m_Rigid.linearVelocity.y);
        else if (m_Rigid.linearVelocity.x < -m_MaxSpeed)  // left
            m_Rigid.linearVelocity = new Vector2(-m_MaxSpeed, m_Rigid.linearVelocity.y);

    }

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
