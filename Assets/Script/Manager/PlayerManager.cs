using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] private PlayerMove playerMove = null;


    public PlayerMove move { get; private set; }

    private void Awake()
    {
        move = playerMove;

        if (move == null)
            Debug.Log("playerMove is NULL!!!!");
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        move.Walk();
    }


}
