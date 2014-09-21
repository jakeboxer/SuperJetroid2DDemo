using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public const int IDLE = 0;
	public const int OPENING = 1;
	public const int OPEN = 2;
	public const int CLOSING = 3;

	public float closeDelay = 0.5f;

	private Animator animator;
	private int state = IDLE;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Open () {
		animator.SetInteger("AnimState", 1);
	}

	public void Close () {
		StartCoroutine(CloseNow());
	}

	void OnOpenStart () {
		state = OPENING;
	}
	
	void OnOpenEnd () {
		state = OPEN;
	}
	
	void OnCloseStart () {
		state = CLOSING;
	}
	
	void OnCloseEnd () {
		state = IDLE;
	}

	void DisableCollider2D () {
		collider2D.enabled = false;
	}
	
	void EnableCollider2D () {
		collider2D.enabled = true;
	}

	private IEnumerator CloseNow () {
		yield return new WaitForSeconds(closeDelay);
		animator.SetInteger("AnimState", 2);
	}
}
