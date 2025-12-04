using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInputField;  // ✅ TMP version of InputField
    public TMP_Text bestScoreText;

    void Start()
    {
        if (PlayerData.Instance != null)
        {
            PlayerData.Instance.LoadData();
            if (PlayerData.Instance != null && !string.IsNullOrEmpty(PlayerData.Instance.PlayerName))
            {
                bestScoreText.text = "Best Score: " + PlayerData.Instance.PlayerName + " : " + PlayerData.Instance.BestScore;
            }
            else
            {
                bestScoreText.text = "Best Score:";
            }
            if (!string.IsNullOrEmpty(PlayerData.Instance.PlayerName))
            {
                nameInputField.text = PlayerData.Instance.PlayerName;
            }
        }
    }

    public void StartNew()
    {
        if (!string.IsNullOrEmpty(nameInputField.text))
        {
            PlayerData.Instance.PlayerName = nameInputField.text;
            SceneManager.LoadScene(1); // Load Main Scene (Build Index 1)
        }
        else
        {
            Debug.LogWarning("Please enter your name before starting!");
        }
    }

    public void OnNameEntered(string playerName)
    {
        PlayerData.Instance.PlayerName = playerName;
        Debug.Log("Name entered: " + playerName);
    }


    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // quit Unity player
#endif
    }
}
