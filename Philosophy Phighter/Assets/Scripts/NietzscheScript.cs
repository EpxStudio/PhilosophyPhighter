﻿using UnityEngine;
using System.Collections;

public class NietzscheScript : PlayerScript
{
	void Start()
	{
		LeftKey = KeyCode.A;
		RightKey = KeyCode.D;
		PunchKey = KeyCode.E;
		KickKey = KeyCode.Q;
		JumpKey = KeyCode.W;
		BlockKey = KeyCode.F;
		CrouchKey = KeyCode.S;
		GrappleKey = KeyCode.R;
		GrappleThrowKey = KeyCode.V;

		States["IsFacingRight"] = true;

		SetupComponents();
	}

	void OnGUI()
	{
		GUI.Box(new Rect(0, 0, 100, 50), TotalHealth.ToString());
	}
}
