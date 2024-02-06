using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SavesManager : MonoBehaviour
{
    public static SavesManager Instance;
    public string playerName;
    public int bestScore = 0;
    public string bestPlayerName;

    private void Awake(){
        if(Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadDataFile();
    }

    public void OnInput(string s){
        playerName = s;
    }   
    
    [System.Serializable]
    class SaveData{
        public string playerName;
        public int bestScore;
    }

    public void SaveDataFile(){
        SaveData data = new SaveData();
        data.playerName = bestPlayerName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadDataFile(){
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path)){
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestPlayerName = data.playerName;
            bestScore = data.bestScore;
        }
    }


}
