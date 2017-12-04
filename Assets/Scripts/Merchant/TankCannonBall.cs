using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCannonBall : MonoBehaviour
{
	public GameObject target;
	public float velocity = 10.0f;
	private Animator animator;

	protected void Start()
	{
		this.animator = this.GetComponentInChildren<Animator>();
	}

	protected void OnEnable()
	{
		this.target.SetActive(true);
		this.transform.localPosition = new Vector3(0, 20, 0);
		this.GetComponent<Rigidbody>().velocity = new Vector3(0, -velocity, 0);
	}

	protected IEnumerator OnCollisionEnter()
	{
		this.target.SetActive(false);
		this.animator.SetTrigger("DidCrash");
		yield return new WaitForSecondsRealtime(0.5f);
		TrashMan.despawn(this.transform.parent.gameObject);
	}
}
