using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
	public Transform target;
	public float speed = 2f;
	public float distance = 0.0f;
	public float height = 2.0f;
	public float heightDamping = 2.0f;

	public float lookAtHeight = 0.0f;

	public Rigidbody parentRigidbody;

	public float rotationSnapTime = 2F;

	public float distanceSnapTime = 0.1f;
	public float distanceMultiplier = 0.1f;

	private Vector3 lookAtVector;

	private float usedDistance;

	float wantedRotationAngle;
	float wantedHeight;

	float currentRotationAngle;
	float currentHeight;

	Quaternion currentRotation;
	Vector3 wantedPosition;
	private float yVelocity = 0.0F;
	private float zVelocity = 0.0F;
	void Start()
	{
		lookAtVector = new Vector3(0, lookAtHeight, 0);
	}

	void LateUpdate()
	{
		float interpolation = speed * Time.deltaTime;

		wantedHeight = target.position.y + height;
		currentHeight = transform.position.y;

		wantedRotationAngle = target.eulerAngles.y;
		currentRotationAngle = transform.eulerAngles.y;

		// currentRotationAngle = Mathf.SmoothDampAngle(currentRotationAngle, wantedRotationAngle, ref yVelocity, rotationSnapTime);
		currentRotationAngle = Mathf.Lerp(currentRotationAngle, wantedRotationAngle, rotationSnapTime);
		currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

		wantedPosition = target.position;
		wantedPosition.y = currentHeight;

		usedDistance = Mathf.SmoothDampAngle(usedDistance, distance + (parentRigidbody.velocity.magnitude * distanceMultiplier), ref zVelocity, distanceSnapTime);

		wantedPosition += Quaternion.Euler(0, currentRotationAngle, 0) * new Vector3(0, 0, -usedDistance);

		// wantedPosition.x = Mathf.Lerp(transform.position.x, wantedPosition.x, interpolation);
		// wantedPosition.y = Mathf.Lerp(transform.position.y, wantedPosition.y, interpolation);
		// wantedPosition.z = Mathf.Lerp(transform.position.z, wantedPosition.z, interpolation);
		wantedPosition = Vector3.Lerp(transform.position, wantedPosition, interpolation);
		transform.position = wantedPosition;
		transform.LookAt(target.position + lookAtVector);
	}


}
