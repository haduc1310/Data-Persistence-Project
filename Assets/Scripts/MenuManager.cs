using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public InputField nameBox;
    public GameObject statusBox;
    public string playerName;
    public TextMeshProUGUI bestScoreBox;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        nameBox = GameObject.Find("NameBox").GetComponent<InputField>();
        bestScoreBox.text = $"Best Score: {BestScore.Instance.bestScore}";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        if (nameBox.text != "")
        {
            playerName = nameBox.text;
            SceneManager.LoadScene(1);
        }
        else
        {
            statusBox.SetActive(true);
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
    Application.Quit();
#endif
    }

    public void ResetPlayerData()
    {
        BestScore.Instance.bestPlayerName = "";
        BestScore.Instance.bestScore = 0;

        BestScore.Instance.SavePlayerData();
        BestScore.Instance.LoadPlayerData();
        bestScoreBox.text = $"Best Score: {BestScore.Instance.bestScore}";
    }
}
