using UnityEngine;

public class TopDownMovement : MonoBehaviour
{

	public float walkSpeed = 5f;
	public Boundary boundary; // optional rectangle boundary

	float maxSpeed = 10f;
	float curSpeed;

	float sprintSpeed;
	Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		// sprintSpeed = walkSpeed + (walkSpeed / 2);
	}

	void FixedUpdate()
	{
		curSpeed = walkSpeed;
		maxSpeed = curSpeed;

		// the movement magic
		rb.velocity = new Vector3(
			Mathf.Lerp(0, Input.GetAxis("Horizontal") * curSpeed, 0.8f),
			rb.velocity.y,
			Mathf.Lerp(0, Input.GetAxis("Vertical") * curSpeed, 0.8f)
		);

		// optional: clamp position inside a rectangle
		rb.position = new Vector3(
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
			rb.position.y,
			Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
		);
	}
}

// optional rectangle boundary
[System.Serializable]
public struct Boundary
{
	public float xMin;
	public float xMax;
	public float zMin;
	public float zMax;
}