using UnityEngine;
using System.Collections;

public class NietzscheScript : PlayerScript
{
	void Start()
	{
		SetupComponents();

		LeftKey = KeyCode.A;
		RightKey = KeyCode.D;
		PunchKey = KeyCode.E;
		KickKey = KeyCode.Q;
		JumpKey = KeyCode.W;
		BlockKey = KeyCode.F;
		CrouchKey = KeyCode.S;

		States["IsFacingRight"] = true;
	}

	void OnGUI()
	{
		GUI.Box(new Rect(0, 0, 100, 50), TotalHealth.ToString());
	}
}
