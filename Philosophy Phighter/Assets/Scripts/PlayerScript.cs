using UnityEngine;
using System.Collections;
using System;

public class PlayerScript : MonoBehaviour
{
	public float MoveSpeed;
	public GameObject opponent;
	public int TotalHealth;
	public int PunchStrength;
	public int KickStrength;
	public int AerialModifier;
	
	internal Animator anim;
	internal Rigidbody2D rb2d;

	internal KeyCode BlockKey;
	internal KeyCode GrappleKey;
	internal KeyCode GrappleThrowKey;
	internal KeyCode JumpKey;
	internal KeyCode KickKey;
	internal KeyCode LeftKey;
	internal KeyCode PunchKey;
	internal KeyCode RightKey;
	internal KeyCode CrouchKey;

	internal StateTracker<bool> States = new StateTracker<bool>();

	internal PlayerScript OpponentScript
	{
		get
		{
			return opponent.GetComponent<PlayerScript>();
		}
	}

	internal void SetupComponents()
	{
		anim = gameObject.GetComponent<Animator>();
		anim.SetFloat("Speed", 1f);

		rb2d = gameObject.GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		/***************
		 * LEFT & RIGHT
		 ***************/
		if (Input.GetKey(LeftKey) &&
			!States["IsGrappled"] &&
			!States["IsGrappling"])
		{
			transform.position -= transform.right * MoveSpeed * (States["IsCrouching"] ? 0.25f : 1) * Time.deltaTime;
		}

		if (Input.GetKey(RightKey) &&
			!States["IsGrappled"] &&
			!States["IsGrappling"])
		{
			transform.position += transform.right * MoveSpeed * (States["IsCrouching"] ? 0.25f : 1) * Time.deltaTime;
		}

		/***************
		 * JUMPING
		 ***************/
		if (Input.GetKey(JumpKey) &&
			!States["IsAerial"] &&
			!States["IsGrappled"] &&
			!States["IsGrappling"])
		{
			States["IsAerial"] = true;
			rb2d.AddForce(new Vector2(0f, 500f));
		}

		/***************
		 * PUNCHING
		 ***************/
		if (Input.GetKey(PunchKey) &&
			OpponentScript.States["IsInRange"] &&
			!States["HasPunched"] &&
			!States["IsBlocking"] &&
			!States["IsGrappled"] &&
			!States["IsGrappling"])
		{
			OpponentScript.PunchMe(PunchStrength * (States["IsAerial"] ? AerialModifier : 1));
			States["HasPunched"] = true;
		}
		else if (!Input.GetKey(PunchKey) && States["HasPunched"])
		{
			States["HasPunched"] = false;
		}

		/***************
		 * KICKING
		 ***************/
		if (Input.GetKey(KickKey) &&
			OpponentScript.States["IsInRange"] &&
			!States["HasKicked"] &&
			!States["IsBlocking"] &&
			!States["IsCrouching"] &&
			!States["IsGrappled"] &&
			!States["IsGrappling"])
		{
			OpponentScript.KickMe(KickStrength * (States["IsAerial"] ? AerialModifier : 1));
			States["HasKicked"] = true;
		}
		else if (!Input.GetKey(KickKey))
		{
			States["HasKicked"] = false;
		}

		/***************
		 * BLOCKING
		 ***************/
		if (Input.GetKey(BlockKey) &&
			!States["IsBlocking"] &&
			!States["IsGrappled"] &&
			!States["IsGrappling"])
		{
			States["IsBlocking"] = true;
		}
		else if (!Input.GetKey(BlockKey) && States["IsBlocking"])
		{
			States["IsBlocking"] = false;
		}

		/***************
		 * CROUCHING
		 ***************/
		if (Input.GetKey(CrouchKey) &&
			!States["IsCrouching"] &&
			!States["IsGrappled"] &&
			!States["IsGrappling"])
		{
			States["IsCrouching"] = true;
			gameObject.transform.localScale = new Vector3(1.0f, 0.5f, 1.0f);
			GetComponent<CircleCollider2D>().offset = new Vector2(0f, -0.1f);
			GetComponent<Rigidbody2D>().gravityScale = 10f;
		}
		else if (!Input.GetKey(CrouchKey) && States["IsCrouching"])
		{
			States["IsCrouching"] = false;
			gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
			GetComponent<CircleCollider2D>().offset = new Vector2(0f, -0.77f);
			GetComponent<Rigidbody2D>().gravityScale = 2.5f;
		}

		/***************
		 * GRAPPLING
		 ***************/
		if (Input.GetKey(GrappleKey) &&
			States["IsTouching"] &&
			!States["IsGrappling"] &&
			!States["IsGrappled"])
		{
			States["IsGrappling"] = OpponentScript.AttemptGrapple();
		}
		else if (!Input.GetKey(GrappleKey) && States["IsGrappling"])
		{
			OpponentScript.States["IsGrappled"] =
			States["IsGrappling"] = false;
		}

		if (Input.GetKey(GrappleThrowKey) && States["IsGrappling"])
		{
			States["IsGrappling"] = false;
			OpponentScript.States["IsAerial"] = true;
			OpponentScript.rb2d.AddForce(new Vector2(0f, 1500f));
			OpponentScript.States["IsGrappled"] = false;
		}
	}

	void OnTriggerEnter2D(Collider2D C)
	{
		OpponentScript.States["IsInRange"] = true;
	}

	void OnTriggerExit2D(Collider2D C)
	{
		OpponentScript.States["IsInRange"] = false;
	}

	void OnCollisionEnter2D(Collision2D C)
	{
		if (C.collider.GetComponent<PlayerScript>() != null)
		{
			States["IsTouching"] = true;
		}
		else if (C.collider.GetComponent<GroundScript>() != null)
		{
			States["IsAerial"] = false;
		}

	}

	void OnCollisionExit2D(Collision2D C)
	{
		if (C.collider.GetComponent<PlayerScript>() != null)
		{
			States["IsTouching"] = false;
		}
	}

	public void PunchMe(int amount)
	{
		if (!States["IsBlocking"] && !States["IsCrouching"])
		{
			TotalHealth -= amount;
		}
	}

	public void KickMe(int amount)
	{
		if (!States["IsBlocking"])
		{
			TotalHealth -= amount;
		}
	}

	private bool AttemptGrapple()
	{
		if (!States["IsBlocking"] &&
			!States["IsCrouching"] &&
			!States["IsGrappled"])
		{
			States["IsGrappled"] = true;
			return true;
		}
		else
		{
			return false;
		}
	}
}
