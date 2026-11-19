using System;
using UnityEngine;

public class CircularSaw : MonoBehaviour, IStageResultNotice
{
    public event Action<StageResult, Vector2> StageFinished;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        Vector2 direction = (collision.transform.position - transform.position).normalized;

        StageFinished?.Invoke(StageResult.GameOver, direction);
    }
}
