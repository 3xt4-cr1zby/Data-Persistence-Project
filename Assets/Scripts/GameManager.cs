using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int highestScore=0;
    public string hPlayerName;
    public string cPlayerName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    class SaveData
    {
        public string hPlayerName;
        public string cPlayerName;
        public int score;
    }

    public void SaveScore()
    {
        SaveData saveData= new SaveData();
        saveData.hPlayerName = hPlayerName;
        saveData.cPlayerName= cPlayerName;
        saveData.score = highestScore;

        string json=JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "savefile.json", json);

    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "savefile.json"; 
        if (File.Exists(path)){
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            hPlayerName = data.hPlayerName;
            cPlayerName= data.cPlayerName;
            highestScore = data.score;
        }
        
    }


}
