using UnityEngine;
using System.Collections;

public class AccelScript : MonoBehaviour 
{

	public float speed;

	private float moveX;
	private float moveZ;
	private float Sw = Screen.width;

	void Update () 
	{
		//transform.Translate(Input.acceleration.x, 0, -Input.acceleration.z);
		//if (transform.position.x <= (0)) 
		//{
			//transform.position.x = 0;
		//	moveX = 0;
		//} 
		//else if (transform.position.x >= (Sw)) 
		//{
			//position.x = (Sw / 2);
		//	moveX = 0;
		//}
		//else
		//{
		//	float moveX = Input.acceleration.x * speed;
		//}


		float moveX = Input.acceleration.x * speed;
		float moveZ = -Input.acceleration.z * speed;

		transform.Translate(moveX, 0, moveZ);
	}
}