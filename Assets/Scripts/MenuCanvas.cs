using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        MenuManager.Instance.StartGame();
    }

    public void QuitGame()
    {
        MenuManager.Instance.QuitGame();
    }

    public void ResetPlayerData()
    {
        MenuManager.Instance.ResetPlayerData();
    }
}
