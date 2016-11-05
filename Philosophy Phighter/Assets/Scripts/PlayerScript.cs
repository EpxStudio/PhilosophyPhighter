using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
	public float MoveSpeed;
	public GameObject opponent;
	public int TotalHealth;
	public int PunchStrength;

	internal bool IsInRange = false;

	internal Animator anim;
	internal KeyCode LeftKey;
	internal KeyCode RightKey;
	internal KeyCode PunchKey;

	PlayerScript OpponentScript
	{
		get
		{
			return opponent.GetComponent<PlayerScript>();
		}
	}

	// Update is called once per frame
	void Update()
	{

	}

	void FixedUpdate()
	{
		if (Input.GetKey(LeftKey))
		{
			Vector3 newScale = transform.localScale;
			newScale.y = 1.0f;
			newScale.x = 1.0f;
			transform.localScale = newScale;

			transform.position -= transform.right * MoveSpeed * Time.deltaTime;
		}
		else if (Input.GetKey(RightKey))
		{
			Vector3 newScale = transform.localScale;
			newScale.x = 1.0f;
			transform.localScale = newScale;

			transform.position += transform.right * MoveSpeed * Time.deltaTime;
		}

		if (Input.GetKey(PunchKey) && OpponentScript.IsInRange)
		{
			OpponentScript.PunchMe(PunchStrength);
		}
	}

	void OnTriggerEnter(Collider C)
	{
		Debug.Log("Trigger entered");
		OpponentScript.IsInRange = true;
	}

	void OnTriggerExit(Collider C)
	{
		Debug.Log("Trigger left");
		OpponentScript.IsInRange = false;
	}

	public void PunchMe(int amount)
	{
		TotalHealth -= amount;
		Debug.Log(TotalHealth);
	}
}
