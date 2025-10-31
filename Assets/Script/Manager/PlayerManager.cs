using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] private PlayerMove playerMove = null;


    public PlayerMove move { get; private set; }

    private void Awake()
    {
        //move = playerMove;

        if (playerMove == null)
            Debug.Log("playerMove is NULL!!!!");
    }

    private void Update()
    {
        playerMove.Jump();
        playerMove.StopWalkSpeed();
        playerMove.DirectionSprite();
        playerMove.WalkAni();
    }

    private void FixedUpdate()
    {
        playerMove.Walk();
        playerMove.LandingPlatform();
    }


}
