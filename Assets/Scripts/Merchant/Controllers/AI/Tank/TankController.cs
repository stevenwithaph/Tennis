using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prime31.StateKit;
using Merchant.Characters;

public class TankController : AIController
{
	protected TankShoot tankShoot;

	public override void Posses(Character possessing)
	{
		base.Posses(possessing);
		GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
		if(playerGameObject)
		{
			this.player = playerGameObject.GetComponent<Character>();
		}
		this.tankShoot = this.character.GetComponent<TankShoot>();
	}

	protected void Update()
	{
		this.tankShoot.Fire();
	}
}
