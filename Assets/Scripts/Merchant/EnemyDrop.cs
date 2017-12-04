using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    public GameManager.EnemyTypes enemyType;
	public Action<EnemyDrop> OnDrop;

	private void SpawnEnemy()
	{
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
