using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppData : MonoBehaviour
{
	public static AppData Instance = null;

	public string CurrentUsername { get; set; }
	public string HighUsername { get; private set; }

	private int highscore;
	public int HighScore {
		get => highscore;
		set {
			highscore = value;
			HighUsername = CurrentUsername;
			PersistToStorage();
		}
    }

	private void Awake()
	{
		if (null != Instance) {
			Destroy(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);
		LoadFromStorage();
	}

	public class SaveData
	{
		public string username;
		public int highscore;
	}

	public void PersistToStorage()
	{
		SaveData data = new SaveData();
		data.username = CurrentUsername;
		data.highscore = HighScore;

		string path = Application.persistentDataPath + "highscore.json";
		string json = JsonUtility.ToJson(data);
		System.IO.File.WriteAllText(path, json);
    }

	public void LoadFromStorage()
	{ 
		string path = Application.persistentDataPath + "highscore.json";
		if (System.IO.File.Exists(path)) {
			string json = System.IO.File.ReadAllText(path);
			SaveData data = JsonUtility.FromJson<SaveData>(json);
			HighUsername = data.username;
			highscore = data.highscore;
		}
    }
}
