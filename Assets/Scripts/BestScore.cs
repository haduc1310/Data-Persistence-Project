using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class BestScore : MonoBehaviour
{
    public static BestScore Instance;
    public string bestPlayerName;
    public int bestScore = 0;

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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    [SerializeField]
    class PlayerData
    {
        public string playerName;
        public int score;
    }

    public void SavePlayerData()
    {
        PlayerData data = new PlayerData();
        data.playerName = bestPlayerName;
        data.score = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            bestPlayerName = data.playerName;
            bestScore = data.score;
        }
    }
}
