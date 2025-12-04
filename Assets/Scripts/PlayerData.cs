
using UnityEngine;
public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    public string PlayerName;
    public int BestScore;

    private void Awake()
    {
        // Singleton: keep this object between scenes
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadData();
    }

    public void SaveData()
    {
        if (!string.IsNullOrEmpty(PlayerName))
        {
            // 🔹 Save score with the player's name as the key
            PlayerPrefs.SetInt($"{PlayerName}_BestScore", BestScore);         //age usser ke according best score krna h to ISE KRENGE 
            PlayerPrefs.Save();
        }
    }

    //age usser ke according best score krna h to ISE KRENGE 
    //public void SaveData() { PlayerPrefs.SetInt("BestScore", BestScore); PlayerPrefs.Save(); }
    //public void LoadData() { BestScore = PlayerPrefs.GetInt("BestScore", 0); }

    public void LoadData()
    {
        if (!string.IsNullOrEmpty(PlayerName))
        {
            // 🔹 Load the specific player's score
            BestScore = PlayerPrefs.GetInt($"{PlayerName}_BestScore", 0);
        }
        else
        {
            BestScore = 0;
        }
    }

    public void SaveBestScore(int newScore)
    {
        if (newScore > BestScore)
        {
            BestScore = newScore;
            SaveData(); // ✅ Persist it immediately
        }
    }
}

