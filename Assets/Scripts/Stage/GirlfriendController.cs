using System;
using UnityEngine;

public class GirlfriendController : MonoBehaviour, IStageResultNotice
{
    public event Action<StageResult, Vector2> StageFinished;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StageFinished?.Invoke(StageResult.Clear, Vector2.zero);
        }
    }
}
