using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private bool startFacingRight;
    [SerializeField] private float knockbackImpulse = 3f;
    private Rigidbody2D playerRb;
    private Animator playerAnimator;
    private Transform playerTransform;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerRb.simulated = false;
        playerAnimator = GetComponent<Animator>();
        playerTransform = GetComponent<Transform>();
        AnimatorReset();
        SetFacing(startFacingRight);
    }

    private void SetFacing(bool startFacingRight)
    {
        spriteRenderer.flipX = startFacingRight;
    }

    public void RigidOn()
    {
        playerRb.simulated = true;
    }
    public void RigidOFF()
    {
        playerRb.simulated = false;
    }

    private void AnimatorReset()
    {
        if (playerAnimator == null) return;
        playerAnimator.SetBool("death_flag", false);
        playerAnimator.SetBool("goal_flag", false);
        playerAnimator.SetBool("right_goal_flag", false);

    }

    public void GoalAnimation(Transform target)
    {
        // girlfriendの場所で左右反転する
        FaceTarget(target);

        if (playerAnimator == null) return;
        // 体の向きを正して物理をOFFにする
        playerRb.simulated = false;
        playerTransform.rotation = Quaternion.identity;

        playerAnimator.SetBool("goal_flag", true);
    }

    public void DeathAnimation(Vector2 direction)
    {
        // 移動と回転の勢いをリセット
        playerRb.linearVelocity = Vector2.zero;
        playerRb.angularVelocity = 0f;

        playerRb.AddForce(direction * knockbackImpulse, ForceMode2D.Impulse);
        if (playerAnimator == null) return;

        playerAnimator.SetBool("death_flag", true);
    }

    //public void StopKnockback()
    //{
    //    playerRb.linearVelocity =
    //        new Vector2(0f, playerRb.linearVelocity.y);

    //    playerRb.angularVelocity = 0f;
    //}

    // ゴール時のアニメーションの向きを決める
    private void FaceTarget(Transform target)
    {
        float differenceX = target.position.x - transform.position.x;
        if (differenceX <= 0)
        {
            startFacingRight = false;
            SetFacing(startFacingRight);
        }
        else
        {
            startFacingRight = true;
            SetFacing(startFacingRight);
        }
    }
}
