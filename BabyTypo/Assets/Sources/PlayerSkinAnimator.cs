using UnityEngine;

public class PlayerSkinAnimator : MonoBehaviour
{
    public void OnHitEnd()
    {
        GetComponentInParent<Player>().OnHitEnd();
    }
}