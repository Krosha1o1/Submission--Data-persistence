using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    public string playerName;
    public int playerScore;
    public string bestName;
    public int bestScore;
    private void Awake()
    {
        if(Instance!=null)
        {
            Destroy(gameObject);
            }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public string UpdateData()
    {
        HighScore();
        return "Best Score: " + bestName + " : " + bestScore;
    }
    [System.Serializable]
    class SaveData
    {
        public string bestPlayerName;
        public int bestPlayerScore;
    }
    public void SaveHighscore()
    {
        SaveData playerData = new SaveData();
        playerData.bestPlayerName = playerName;
        playerData.bestPlayerScore = playerScore;
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void HighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData playerData = JsonUtility.FromJson<SaveData>(json);
            bestName = playerData.bestPlayerName;
            bestScore = playerData.bestPlayerScore;
        }
    }
}
