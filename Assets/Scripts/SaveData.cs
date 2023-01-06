using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    public static SaveData Instance;
    //public Color TeamColor;
    public string PlayerName;
    public string HighestScore;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPlayerData();
    }

    [System.Serializable]
    class SaveDataAsJson
    {
        public string PlayerName;
        public string HighestScore;
    }

    public void SavePlayerData(string s)
    {
        // Get the name
        GameObject f = GameObject.Find("NameInput");
        Debug.Log(s);
        PlayerName = s;


        SaveDataAsJson data = new SaveDataAsJson();
        //data.TeamColor = TeamColor;
        data.PlayerName = PlayerName;
        data.HighestScore = HighestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    
    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveDataAsJson data = JsonUtility.FromJson<SaveDataAsJson>(json);

            PlayerName = data.PlayerName;
            HighestScore = data.HighestScore;
        }
    }
}
