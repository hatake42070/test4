using UnityEngine;

public class SpringController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private StageManager stageManager;
    private BoxCollider2D springCollider;

    private void Awake()
    {
        springCollider = GetComponent<BoxCollider2D>();
    }

    public void Initialize(StageManager stageManager)
    {
        this.stageManager = stageManager;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && stageManager !=  null && stageManager.CanOperateGimmicks) // クリック感知
        {
            Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (springCollider.OverlapPoint(position))
            {
                OnSpring();
            }
        }
    }

    private void OnSpring()
    {
        if(animator != null)
        {
            animator.SetBool("spring_up_flag", true);
        }
    }

    private void OffSpring()
    {
        if (animator != null)
        {
            animator.SetBool("spring_up_flag", false);
        }
    }
}
