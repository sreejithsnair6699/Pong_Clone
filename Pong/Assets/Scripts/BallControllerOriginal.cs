using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControllerOriginal : MonoBehaviour {

	Rigidbody2D ballBody;

	int flag = 0;

	// Use this for initialization
	void Start () {

		ballBody = GetComponent<Rigidbody2D> ();
		StartCoroutine (Pause());

	}

	// Update is called once per frame
	void Update () {

		if(transform.position.x < -10.5f) {
			flag = 1;
			StartCoroutine (Pause());
		}
		if(transform.position.x > 10.5f) {
			flag = 2;
			StartCoroutine (Pause());
		}

	}

	IEnumerator Pause() {

		yield return new WaitForSeconds (1f);
		BallStartMove ();
	}

	void BallStartMove() {

		transform.position = new Vector3 (0,0,0);

		Vector3 startDirection = new Vector3 ();

		int x_dir = Random.Range (0, 2);
		int y_dir = Random.Range (0, 3);

		if (flag == 1) {
			ScoreCompute.instance.P2_Scored ();
			flag = 0;
		}

		if (flag == 2) {
			ScoreCompute.instance.P1_Scored ();
			flag = 0;
		}

		if (x_dir == 0) {
			startDirection.x = 8f;
		}

		if (x_dir == 1) {
			startDirection.x = -8f;
		}

		if (y_dir == 0) {
			startDirection.y = 8f;
		}

		if (y_dir == 1) {
			startDirection.y = -8f;
		}

		if (y_dir == 2) {
			startDirection.y = 0f;
		}

		ballBody.velocity = startDirection;
	}

	void OnCollisionEnter2D (Collision2D collide){

		if (collide.gameObject.name == "BoundUpper") {

			float speed = 0f;

			if (ballBody.velocity.x > 0f) {
				speed = 8f;
			}

			if (ballBody.velocity.x <= 0f) {
				speed = -8f;
			}

			ballBody.velocity = new Vector3 (speed, -8f, 0);

		}

		if (collide.gameObject.name == "BoundLower") {

			float speed = 0f;

			if (ballBody.velocity.x > 0f) {
				speed = 8f;
			}

			if (ballBody.velocity.x <= 0f) {
				speed = -8f;
			}

			ballBody.velocity = new Vector3 (speed, 8f, 0);

		}

		if (collide.gameObject.name == "leftPaddle") {
			ballBody.velocity = new Vector3 (10f, 0f, 0);

			if (transform.position.y - collide.gameObject.transform.position.y < -0.35) {
				ballBody.velocity = new Vector3 (7f, -7f, 0);
			}

			if (transform.position.y - collide.gameObject.transform.position.y > 0.35) {
				ballBody.velocity = new Vector3 (7f, 7f, 0);
			}



		}

		if (collide.gameObject.name == "rightPaddle") {

			ballBody.velocity = new Vector3 (-10f, 0f, 0);

			if (transform.position.y - collide.gameObject.transform.position.y < -0.35) {
				ballBody.velocity = new Vector3 (-7f, -7f, 0);
			}

			if (transform.position.y - collide.gameObject.transform.position.y > 0.35) {
				ballBody.velocity = new Vector3 (-7f, 7f, 0);
			}


		}

	}

}
