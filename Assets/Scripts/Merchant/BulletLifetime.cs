using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLifetime : MonoBehaviour {

	public float lifeTime = 0.0f;

	// Use this for initialization
	void Start () 
	{
		this.StartCoroutine(this.LifeTimeCoroutine());
	}
	
	IEnumerator LifeTimeCoroutine()
	{
		yield return new WaitForSecondsRealtime(this.lifeTime);

		Destroy(this.gameObject);
	}
}
