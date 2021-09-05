using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance;

    [SerializeField]
    private GameObject GameEndingUI;
    [SerializeField]
    private Text m_Score;

    [SerializeField]
    private bool m_GameOver = false;

    private int m_Points = 0;

    public bool GameOver
    {
        get
        {
            return m_GameOver;
        }

        set
        {
            GameEndingUI.SetActive(true);
            m_GameOver = true;
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void AddPoint()
    {
        m_Points += 10;
        m_Score.text = "Score: " + m_Points;
    }

    public void RestartTheGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitTheGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
