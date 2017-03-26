using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class movePlayerXY : MonoBehaviour
{
	public float moveSpeed = 10f;
	public float turnSpeed = 50f;
	private bool moveLeft;
	private bool moveRight;
	private bool moveFwd;
	private bool moveBwd;


	void Update ()
	{
		if (moveFwd && !moveBwd)
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

		if (moveBwd && !moveFwd)
			transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);

		if (moveLeft && !moveRight)
			transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
		
		if (moveRight && !moveLeft)
			transform.Translate(-Vector3.left * moveSpeed * Time.deltaTime);
	}

	public void MoveMeLeft()
	{
		moveLeft = true;
	}

	public void StopMeLeft()
	{
		moveLeft = false;
	}
	public void MoveMeRight()
	{
		moveRight = true;
	}

	public void StopMeRight()
	{
		moveRight = false;
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
