using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class moveDial : MonoBehaviour
{
	public float moveSpeed = 10f;
	public float turnSpeed = 50f;
	private bool rotateLeft;
	private bool rotateRight;
	private bool moveFwd;
	private bool moveBwd;


	void Update ()
	{
		if (moveFwd && !moveBwd)
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

		if (moveBwd && !moveFwd)
			transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);

		if (rotateLeft && !rotateRight)
			transform.Rotate(Vector3.forward, -turnSpeed * Time.deltaTime);

		if (rotateRight && !rotateLeft)
			transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
	}

	public void RotateMeLeft()
	{
		rotateLeft = true;
	}

	public void StopMeLeft()
	{
		rotateLeft = false;
	}
	public void RotateMeRight()
	{
		rotateRight = true;
	}

	public void StopMeRight()
	{
		rotateRight = false;
	}

	public void MoveMeFwd()
	{
		moveFwd = true;
	}

	public void StopMeFwd()
	{
		moveFwd = false;
	}

	public void MoveMeBwd()
	{
		moveBwd = true;
	}

	public void StopMeBwd()
	{
		moveBwd = false;
	}

}
