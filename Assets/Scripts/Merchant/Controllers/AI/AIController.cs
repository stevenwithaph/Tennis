using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Merchant.Characters;
using Merchant.Controllers.Base;

public class AIController : Controller {

	protected Character player;
	protected TankShoot tankShoot;

	public float attackRange = 10.0f;
	public float minimumDistance = 5.0f;
        
	protected virtual void Awake()
	{
		GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
		if(playerGameObject)
		{
			this.player = playerGameObject.GetComponent<Character>();
		}

		this.tankShoot = this.character.GetComponent<TankShoot>();
	}

	protected Vector3 VectorToTarget()
	{
		return (this.player.transform.position - this.character.transform.position).normalized;
	}

	protected bool IsTargetInRange()
	{
		return (Vector3.Distance(this.player.transform.position, this.character.transform.position) <= this.attackRange);
	}

	protected bool IsInMinimumDistance()
	{
		return (Vector3.Distance(this.player.transform.position, this.character.transform.position) <= this.minimumDistance);
	}

	protected virtual void Start()
	{
		this.Posses(this.character);
	}

	public override void Posses(Character character)
	{
		base.Posses(character);
		this.character.health.OnDeath += Unposses;
	}

	public override void Unposses()
	{
		Destroy(this.character.gameObject);
		base.Unposses();
		Destroy(this.gameObject);
	}
}
