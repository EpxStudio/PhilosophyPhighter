using UnityEngine;
using System.Collections;

public class SocratesScipt : PlayerScript
{
	void Start()
	{
		SetupComponents();

		LeftKey = KeyCode.LeftArrow;
		RightKey = KeyCode.RightArrow;
		PunchKey = KeyCode.PageUp;
		KickKey = KeyCode.PageDown;
		JumpKey = KeyCode.UpArrow;
		BlockKey = KeyCode.RightControl;
		CrouchKey = KeyCode.DownArrow;
		GrappleKey = KeyCode.RightShift;
		GrappleThrowKey = KeyCode.Slash;

		States["IsFacingRight"] = false;
	}

	void OnGUI()
	{
		GUI.Box(new Rect(Screen.width - 100, 0, 100, 50), TotalHealth.ToString());
	}
}
