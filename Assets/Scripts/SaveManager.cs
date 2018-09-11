using System.Collections;
using UnityEngine;

public class SaveManager : MonoBehaviour {

    public static SaveManager Instance { set; get; }
    public SaveState state;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        Instance = this;
        Load();

        Debug.Log(Helper.Serialize<SaveState>(state));
    }

    //SAVE
    public void Save()
    {
        PlayerPrefs.SetString("save", Helper.Serialize<SaveState>(state));
    }

    //LOAD
    public void Load()
    {
        if (PlayerPrefs.HasKey("save"))
        {
            state = Helper.Deserialize<SaveState>(PlayerPrefs.GetString("save"));
        }
        else
        {
            state = new SaveState(); //state.TotalGold = 2272; //BORRAR <----
            Save();
            Debug.Log("Creating a save file");
        }
    }

    //RESET
    public void Reset()
    {
        PlayerPrefs.DeleteKey("save");
    }

    //GUARDAR HIGHSCORE
    public bool SaveScore(int ScoreGanado)
    {
        if (ScoreGanado > state.Highscore)
        {
            state.Highscore = ScoreGanado;
            Save();
            return true;
        }
        else
        {
            return false;
        }

    }
}
