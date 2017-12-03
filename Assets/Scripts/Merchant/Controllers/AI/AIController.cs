using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Merchant.Characters;
using Merchant.Controllers.Base;

public class AIController : Controller {

	protected Character player;

	protected TankShoot tankShoot;
        
	protected void Awake()
	{
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
