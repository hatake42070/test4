using System;
using UnityEngine;

public class CircularSaw : MonoBehaviour, IStageResultNotice
{
    public event Action<StageResult> StageFinished;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StageFinished?.Invoke(StageResult.GameOver);
        }
    }
}
