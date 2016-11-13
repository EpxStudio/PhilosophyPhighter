using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour
{
	public void LoadScene(string name)
	{
		Application.LoadLevel(name);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
