using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{

	public void Exit()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.ExitPlaymode();
#else
		Application.Quit();
#endif
	}

	public void StartGame()
	{
		SceneManager.LoadScene("main", LoadSceneMode.Single);
    }

	public void NameChanged(string name)
	{
		AppData.Instance.CurrentUsername = name;
    }
}
