using UnityEngine;
using System.Collections;
using System;

public class CharacterSelector : MonoBehaviour
{
	public Character? Player1;
	public Character? Player2;

	void OnGUI()
	{
		GUI.Box(new Rect(0, 0, 100, 50), "Player 1\r\n" +
			(Player1 == null ?
				"Please Select" :
				Enum.GetName(typeof(Character), Player1)
			)
		);

		GUI.Box(new Rect(Screen.width - 100, 0, 100, 50), "Player 2\r\n" +
			(Player2 == null ?
				(Player1 == null? "" : "Please Select") :
				Enum.GetName(typeof(Character), Player2)
			)
		);
	}

	public void SelectCharacter(string character)
	{
		Character selected = Character.Nietzsche;

		switch (character.ToLower())
		{
			case "nietzsche":
				selected = Character.Nietzsche;
				break;

			case "socrates":
				selected = Character.Socrates;
				break;
		}

		if (Player1 == null)
		{
			Player1 = selected;
		}
		else if (Player2 == null)
		{
			Player2 = selected;
		}
	}
	public void LoadScene(string name)
	{
		Application.LoadLevel(name);
	}
}

public enum Character
{
	Nietzsche,
	Socrates
}
