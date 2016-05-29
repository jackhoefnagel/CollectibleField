using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;

	private Rigidbody rb;
	private MeshRenderer mR;
	public Gradient resourcesFullnessGradient;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		mR = GetComponent<MeshRenderer>();
	}

	void Update()
	{
		CheckColor();
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);

		rb.drag = GameManager.instance.playerDrag;

		GameManager.instance.ChangePlayerSpeed(rb.velocity.magnitude);
	}

	public void CheckColor()
	{
		float fullness = GameManager.instance.currentPlayerResources / GameManager.instance.maxPlayerResources;
		mR.material.SetColor("_Color",resourcesFullnessGradient.Evaluate(fullness));
	}
}