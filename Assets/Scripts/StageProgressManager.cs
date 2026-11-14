using UnityEngine;

/// <summary>
/// ステージの進捗（クリア状況）を管理する
/// </summary>
public class StageProgressManager
{
    private int nextStageIndex = 0;

    private readonly SaveManager saveManager;
    private readonly StageSaveData stageData;

    public StageProgressManager(SaveManager saveManager)
    {
        this.saveManager = saveManager;
        stageData = saveManager.Data.stage;
    }

    public void RecordClear(int stageIndex, int score)
    {
        stageData.stageClearRanks[stageIndex] = Mathf.Max(stageData.stageClearRanks[stageIndex], score);
        saveManager.Save();
    }

    public int GetClearRank(int stageIndex)
    {
        return stageData.stageClearRanks[stageIndex];
    }

    public bool IsStageUnlocked(int stageIndex)
    {
        return stageData.isStageUnlocked[stageIndex];
    }

    public void SetNextStageIndex(int stageIndex)
    {
        nextStageIndex = stageIndex;
    }

    public int GetNextStageIndex()
    {
        return nextStageIndex;
    }
}
