using System;
using UnityEngine;

public enum StageResult
{
    Clear,
    GameOver
}

// ゲームの結果に直接影響を与える処理
public interface IStageResultNotice
{
    event Action<StageResult, Vector2> StageFinished;
}
