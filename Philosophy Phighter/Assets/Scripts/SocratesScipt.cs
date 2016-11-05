using UnityEngine;
using System.Collections;

public class SocratesScipt : PlayerScript
{
	void Start()
	{
		anim = gameObject.GetComponent<Animator>();
		anim.SetFloat("Speed", 1f);

		LeftKey = KeyCode.LeftArrow;
		RightKey = KeyCode.RightArrow;
		PunchKey = KeyCode.PageUp;
	}
}
