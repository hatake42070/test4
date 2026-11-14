using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class TitleUIManager : MonoBehaviour
{
    private SequenceManager sequenceManager;
    [SerializeField] private Button startButton;
    [SerializeField] private Button optionButton;
    [SerializeField] private Button closeOptionPanel;
    [SerializeField] private GameObject optionPanel;
    [SerializeField] private Button exitButton;
    [SerializeField] private GameObject exitPanel;
    [SerializeField] private Button exitConfirmButton;
    [SerializeField] private Button exitCancelButton;

    [Inject]
    public void Construct(SequenceManager sequenceManager)
    {
        this.sequenceManager = sequenceManager;
    }

    private void Start()
    {
        startButton.onClick.AddListener(() => sequenceManager.ChangeScene("StageSelectScene"));
        optionButton.onClick.AddListener(OpenOptionPanel);
        closeOptionPanel.onClick.AddListener(CloseSettingPanel);
        optionPanel.SetActive(false);
        exitButton.onClick.AddListener(OpenExitPanel);
        exitPanel.SetActive(false);
        exitConfirmButton.onClick.AddListener(GameExit);
        exitCancelButton.onClick.AddListener(CloseExitPanel);
    }

    private void OpenOptionPanel()
    {
        optionPanel.SetActive(true);
        exitButton.enabled = false;
    }

    private void CloseSettingPanel()
    {
        optionPanel.SetActive(false);
        exitButton.enabled = true;
    }

    private void OpenExitPanel()
    {
        exitPanel.SetActive(true);
        optionButton.enabled = false;
    }

    private void CloseExitPanel()
    {
        exitPanel.SetActive(false);
        optionButton.enabled = true;
    }

    // ゲーム終了処理（Unityエディタとビルド後で処理を変える）
    private void GameExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
