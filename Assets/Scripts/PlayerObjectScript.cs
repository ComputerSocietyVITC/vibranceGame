using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectScript : MonoBehaviour
{
	// Start is called before the first frame update
	private GameObject rigidBody;
	public float speed = 10f;
	void Start()
	{
		rigidBody = GetComponent<GameObject>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(Vector3.forward * Time.deltaTime*speed);
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(Vector3.back * Time.deltaTime*speed);
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Rotate(Vector3.up * -50*Time.deltaTime, Space.World);
			// transform.Translate(Vector3.left * Time.deltaTime*speed);
			// transform.RotateAround(this.transform.position, Vector3.up, 20 * Time.deltaTime);
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			// transform.Rotate(0, 10*Time.deltaTime, 0, Space.Self);
			// transform.Translate(Vector3.right * Time.deltaTime*speed);
			transform.Rotate(Vector3.up * 50*Time.deltaTime, Space.World);
		}
	}
}
