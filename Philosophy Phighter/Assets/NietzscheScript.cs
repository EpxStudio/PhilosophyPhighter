using UnityEngine;
using System.Collections;

public class NietzscheScript : MonoBehaviour
{
	public Animator anim;
	public float MoveSpeed;

	// Use this for initialization
	void Start()
	{
		anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update()
	{
	}

	void FixedUpdate()
	{
		anim.SetFloat("Speed", 1f);

		if (Input.GetKey(KeyCode.A))
		{
			Vector3 newScale = transform.localScale;
			newScale.y = 1.0f;
			newScale.x = 1.0f;
			transform.localScale = newScale;

			transform.position -= transform.right * MoveSpeed * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.D))
		{
			Vector3 newScale = transform.localScale;
			newScale.x = 1.0f;
			transform.localScale = newScale;

			transform.position += transform.right * MoveSpeed * Time.deltaTime;
		}
	}
}
