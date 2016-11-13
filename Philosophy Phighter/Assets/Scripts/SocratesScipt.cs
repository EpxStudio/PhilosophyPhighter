using UnityEngine;
using System.Collections;

public class SocratesScipt : PlayerScript
{
	void Start()
	{
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

		SetupComponents();
	}

	void OnGUI()
	{
		GUI.Box(new Rect(Screen.width - 100, 0, 100, 50), TotalHealth.ToString());
	}
}
