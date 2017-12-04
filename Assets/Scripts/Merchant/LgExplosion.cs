using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LgExplosion : MonoBehaviour
{
	public AudioClip clip;

	private AudioSource source;

    public void Start()
	{
		this.source = this.GetComponent<AudioSource>();
	}

	private void Destroy()
	{
		TrashMan.despawn(this.gameObject);
	}
}