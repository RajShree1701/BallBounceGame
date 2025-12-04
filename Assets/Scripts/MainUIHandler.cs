

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUIHandler : MonoBehaviour
{
	public Text scoreText;
	public Text bestScoreText;

	private int currentScore = 0;

	void Start()
	{
		// ✅ Always reset current score to 0 when the scene starts
		currentScore = 0;
		scoreText.text = "Score: " + currentScore;

		// ✅ Show best score if data exists
		if (PlayerData.Instance != null)
		{
			bestScoreText.text = "Best Score: " + PlayerData.Instance.PlayerName + " : " + PlayerData.Instance.BestScore;
		}
		else
		{
			bestScoreText.text = "Best Score:";
		}
	}

	public void AddScore(int points)
	{
		// ✅ Update current score
		currentScore += points;
		scoreText.text = "Score: " + currentScore;

		// ✅ Update Best Score if player beats it
		if (PlayerData.Instance != null && currentScore > PlayerData.Instance.BestScore)
		{
			PlayerData.Instance.BestScore = currentScore;
			//bestScoreText.text = "Best Score: " + PlayerData.Instance.PlayerName + " : " + PlayerData.Instance.BestScore;
			bestScoreText.text = "Best Score: " + PlayerData.Instance.PlayerName + " : " + PlayerData.Instance.BestScore;

			PlayerData.Instance.SaveData(); // ✅ Save new best score
		}
	}

	public void GameOver()
	{
		// ✅ Ensure latest best score is saved before going back
		PlayerData.Instance.SaveData();
		SceneManager.LoadScene(0); // Return to menu
	}

	public void BackToMenu()
	{
		PlayerData.Instance.SaveData(); // ✅ Save before returning
		SceneManager.LoadScene(0);
	}
}

