using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float jumpStrength;
	public float moveSpeed;

	private bool jump;
	private bool left;
	private bool right;

	public bool standing;
	public bool ground;
	public bool walking;
	public bool facingRight;
	public bool jumping;

	private Rigidbody2D body2d;

	// Use this for initialization
	void Awake () {
		body2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		jump = (Input.GetKeyDown(KeyCode.Space) && ground);
		left = Input.GetKey(KeyCode.LeftArrow);
		right = Input.GetKey(KeyCode.RightArrow);

		// Jump
		if (jump) {
			body2d.velocity = body2d.velocity + Vector2.up * jumpStrength;
			jumping = true;
		}

		// Move left/right
		if (left) {
			body2d.velocity = new Vector2(-moveSpeed, body2d.velocity.y);
			if (ground) {
				walking = true;
			}
			standing = false;
		} else if (right) {
			body2d.velocity = new Vector2(moveSpeed, body2d.velocity.y);
			if (ground) {
				walking = true;
			}
			standing = false;
		}
		if ((left && right) || (!left && !right)) {
			body2d.velocity = new Vector2 (0, body2d.velocity.y);
			standing = true;
			walking = false;
		}

		// Deal with reversing the sprite
		if (body2d.velocity.x < 0) {
			if (facingRight) {
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;
				facingRight = false;
			}
		} else if (body2d.velocity.x > 0) {
			if (!facingRight) {
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;
				facingRight = true;
			}
		}

	}

	// Collision with ground, set jumping to false
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Ground") {
			ground = true;
			jumping = false;
		}
	}
	void OnCollisionExit2D(Collision2D col) {
		if (col.gameObject.tag == "Ground") {
			ground = false;
		}
	}
}
