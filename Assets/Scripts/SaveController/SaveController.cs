using UnityEngine;
using System.IO;

public class SaveController : MonoBehaviour
{
    private static SaveController _instance;

    public static SaveController Instance
    {
        get
        {
            if(_instance == null)
                Debug.Log("SaveController is null!");
            return _instance;
        }
    }

    private string fileSaveName = "/savefile.json";

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SaveTime(float shortestTime)
    {
        SaveTimeData saveTimeData = new SaveTimeData {shortestTime = shortestTime};

        string json = JsonUtility.ToJson(saveTimeData);
        File.WriteAllText(Application.persistentDataPath + fileSaveName, json);
    }

    public float LoadSaveTime()
    {
        float shortestTime = 0f;
        string path = Application.persistentDataPath + fileSaveName;
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveTimeData saveTimeData = JsonUtility.FromJson<SaveTimeData>(json);
            shortestTime = saveTimeData.shortestTime;
        }

        return shortestTime;
    }
}
