
using UnityEngine;
using System.Collections;

public class HydrantMovement : MonoBehaviour {

	public float moveSpeed;
	public bool movingright = true;
	public int distancetoplayer;
	private Rigidbody2D body2d;
	private Transform my_transform;
	private Transform player_transform;
	private GameObject player;
	private Animator animator;

	void Awake () {
		body2d = GetComponent<Rigidbody2D> ();
		my_transform = GetComponent<Transform> ();

		animator = GetComponent<Animator> ();

		player = GameObject.Find ("Player");
		player_transform = player.GetComponent<Transform> ();
	}

	// Update is called once per frame
	void Update () {
		// update distance to player
		distancetoplayer = Mathf.Abs((int)player_transform.position.x - (int)my_transform.position.x);
		animator.SetInteger ("distance_from_player", distancetoplayer);

		// if he's close, then walk
		if (distancetoplayer < 50) {
			if (movingright) {
				body2d.velocity = new Vector2(moveSpeed, 0);
			}
			if (!movingright) {
				body2d.velocity = new Vector2(-moveSpeed, 0);
			}
		}
	}

	// Collision with ground, set jumping to false
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Ground") {
			movingright = !movingright;
		}
		if (col.gameObject.tag == "Player") {
			movingright = !movingright;
		}
	}
}
