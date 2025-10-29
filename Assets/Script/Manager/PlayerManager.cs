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
        move.Jump();
        move.StopWalkSpeed();
        move.DirectionSprite();
        move.WalkAni();
    }

    private void FixedUpdate()
    {
        move.Walk();
        move.LandingPlatform();
    }


}
