using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Controller : MonoBehaviour
{

	Rigidbody2D ballBody;

	public int recentHit = 0;

	int flag = 0;

	public GameObject hitParticle;
	public GameObject spawnParticle;
	public GameObject breakParticle;
	public GameObject paddleLeft, paddleRight;

	public AudioClip hit, collect, breakPaddle;

	// Use this for initialization
	void Start ()
	{
		ballBody = GetComponent<Rigidbody2D> ();
		StartCoroutine (Pause ());
		paddleLeft.SetActive (false);
		paddleRight.SetActive (false);

		GetComponent<AudioSource> ().playOnAwake = false;
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (transform.position.x < -10.5) {
			flag = 1;
			StartCoroutine (Pause ());

		}

		if (transform.position.x > 10.5) {
			flag = 2;
			StartCoroutine (Pause ());


		}
	}

	IEnumerator Pause ()
	{

		yield return new WaitForSeconds (2f);
		Instantiate (spawnParticle, ballBody.transform.position, ballBody.transform.rotation);
		BallStartMove ();
	}

	void BallStartMove ()
	{

		transform.position = new Vector3 (0, 0, 0);
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

	void OnCollisionEnter2D (Collision2D collide)
	{

		Instantiate (hitParticle, ballBody.transform.position, ballBody.transform.rotation);

		if (collide.gameObject.name == "BoundUpper") {

			GetComponent<AudioSource> ().clip = hit;
			GetComponent<AudioSource> ().Play ();
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

			GetComponent<AudioSource> ().clip = hit;

			GetComponent<AudioSource> ().Play ();
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
			GetComponent<AudioSource> ().clip = hit;
			GetComponent<AudioSource> ().Play ();
			ballBody.velocity = new Vector3 (10f, 0f, 0);
			recentHit = 1;

			if (transform.position.y - collide.gameObject.transform.position.y < -0.3) {
				ballBody.velocity = new Vector3 (7f, -7f, 0);
			}

			if (transform.position.y - collide.gameObject.transform.position.y > 0.3) {
				ballBody.velocity = new Vector3 (7f, 7f, 0);
			}


				
		}

		if (collide.gameObject.name == "rightPaddle") {
			GetComponent<AudioSource> ().clip = hit;
			GetComponent<AudioSource> ().Play ();
			ballBody.velocity = new Vector3 (-10f, 0f, 0);
			recentHit = 2;

			if (transform.position.y - collide.gameObject.transform.position.y < -0.3) {
				ballBody.velocity = new Vector3 (-7f, -7f, 0);
			}

			if (transform.position.y - collide.gameObject.transform.position.y > 0.3) {
				ballBody.velocity = new Vector3 (-7f, 7f, 0);
			}


		}
		if (collide.gameObject.name == "S_PowerPaddleRight") {
			GetComponent<AudioSource> ().clip = breakPaddle;
			GetComponent<AudioSource> ().Play ();
			Instantiate (breakParticle, collide.transform.position, collide.transform.rotation);
			paddleRight.SetActive (false);
		}
		if (collide.gameObject.name == "S_PowerPaddleLeft") {
			GetComponent<AudioSource> ().clip = breakPaddle;
			GetComponent<AudioSource> ().Play ();
			Instantiate (breakParticle, collide.transform.position, collide.transform.rotation);
			paddleLeft.SetActive (false);
		}
	}

	public void OnTriggerEnter2D (Collider2D collide) {
		if (collide.gameObject.CompareTag ("Collectables")) {
			GetComponent<AudioSource> ().clip = collect;
			GetComponent<AudioSource> ().Play ();
			collide.gameObject.SetActive (false);
		}
		if (recentHit == 1) {
			paddleLeft.SetActive (true);
		}
		if (recentHit == 2) {
			paddleRight.SetActive (true);
		}	
				
	}

}
