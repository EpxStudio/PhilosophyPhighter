using UnityEngine;
using System.Collections;

public class NietzscheScript : PlayerScript
{
	void Start()
	{
		anim = gameObject.GetComponent<Animator>();
		anim.SetFloat("Speed", 1f);

		LeftKey = KeyCode.A;
		RightKey = KeyCode.D;
		PunchKey = KeyCode.E;
	}
}
