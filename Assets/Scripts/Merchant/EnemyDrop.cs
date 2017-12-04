using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    public GameManager.EnemyTypes enemyType;
	public Action<EnemyDrop> OnDrop;

	public AudioClip clip;

	private AudioSource source;

	public void Start()
	{
		this.source = this.GetComponent<AudioSource>();
	}

	private void SpawnEnemy()
	{
		this.source.PlayOneShot(clip);

		if(this.OnDrop != null)
		{
			this.OnDrop(this);
		}
	}

	private void Destroy()
	{
		TrashMan.despawn(this.gameObject);
	}
}
