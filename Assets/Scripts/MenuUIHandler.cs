using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public Text userNameField;
    public Text bestScoreField;

    private void Start()
    {
        if (PlayerManager.Instance != null)
        {
            bestScoreField.text = PlayerManager.Instance.UpdateData();
        }
        else
        {
            bestScoreField.text = "Best Score: : 0";
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        ChangeName();
    }
    public void ExitApp()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    public void ChangeName()
    {
        if (PlayerManager.Instance != null)
        {
            PlayerManager.Instance.playerName = userNameField.text.ToString();
        }
    }
}
