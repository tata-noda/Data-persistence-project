using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    
    public static DataManager Instance;
    private static string jsonPath;
    public HighScore highScore;

    public string playerName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        jsonPath = Application.persistentDataPath + "/highscoresfile.json";
        playerName = "Anonymous";
    }

    [System.Serializable]
    public class HighScore
    {
        public string playerName;
        public int playerScore;
    }

    public void SaveHighScore(int playerScore)
    {
        HighScore highScoreData = new HighScore();

        highScoreData.playerName = playerName;
        highScoreData.playerScore = playerScore;

        string json = JsonUtility.ToJson(highScoreData);
        File.WriteAllText(jsonPath, json);
    }

    public void LoadHighScore()
    {
        if (File.Exists(jsonPath))
        {
            string json = File.ReadAllText(jsonPath);
            HighScore highScoreData = JsonUtility.FromJson<HighScore>(json);
            highScore = highScoreData;
        }
        else
        {
            highScore = new HighScore();
            highScore.playerName = playerName;
            highScore.playerScore = 0;
        }
    }

}
