using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Merchant.Characters;

public class TankCannon : Weapon
{
	protected Character player;

	void Start()
	{
		GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
		if(playerGameObject)
		{
			this.player = playerGameObject.GetComponent<Character>();
		}
	}

	protected override GameObject SpawnBullet(int currentBulletCount)
	{
		Vector3 offset = new Vector3(Random.Range(0, this.accuracy), 0, Random.Range(0, this.accuracy));
		Vector3 position = this.player.transform.position;

		GameObject bullet = Instantiate(
            this.bullet,
            position + offset,
            Quaternion.identity
        );

		return bullet;
	}
}
