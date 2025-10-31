using UnityEngine;

public class CommonFuction
{
    // Animator
    public static void SetBool(Animator ani, string name, bool value)
    {
        if (ani == null)
            return;

        ani.SetBool(name, value);
    }
}

public enum EnemyType
{
    Plant,
    Snail,
    Bee,
    Max
}
