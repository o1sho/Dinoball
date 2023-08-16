using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[System.Serializable]
public class Data
{
    public int maxScore;
}

public class Database : MonoBehaviour
{
    //Yandex Server Save
    [DllImport("__Internal")]
    private static extern void SaveExtern(string data);

    [DllImport("__Internal")]
    private static extern void LoadExtern();

    public Data data;
    private string saveKey;

    public static Database instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

#if UNITY_EDITOR
            LoadGameData();
#endif
#if !UNITY_EDITOR && UNITY_WEBGL
            LoadExtern();
#endif

        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveGameData()
    {
        string jsonData = JsonUtility.ToJson(data);
#if UNITY_EDITOR
        PlayerPrefs.SetString(saveKey, jsonData);
        PlayerPrefs.Save();
#endif
#if !UNITY_EDITOR && UNITY_WEBGL
        SaveExtern(jsonData);
#endif
    }

    public void LoadGameData()
    {
        if (PlayerPrefs.HasKey(saveKey))
        {
            string jsonData = PlayerPrefs.GetString(saveKey);
            data = JsonUtility.FromJson<Data>(jsonData); 
            Debug.Log("Data found, stored values loaded!");
        }
        else
        {

            data = new Data();
            Debug.Log("No data found, standard values loaded!");
        }
    }

    public void LoadGameDataYandex(string value)
    {
        data = JsonUtility.FromJson<Data>(value);
    }



    //highScore
    public void SetMaxScore(int score)
    {
        data.maxScore = score;
    }

    public int GetMaxScore()
    {
        return data.maxScore;
    }
    //

}