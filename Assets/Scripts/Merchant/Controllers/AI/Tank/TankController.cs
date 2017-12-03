using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prime31.StateKit;

public class TankController : AIController
{
	public float attackRange = 10.0f;

	public float minTimeBetweenAttacks = 2.0f;
	public float maxTimeBetweenAttacks = 5.0f;

	protected SKStateMachine<TankController> machine;

	void Start()
	{
		this.machine = new SKStateMachine<TankController>( this, new WalkingState() );
		this.machine.addState(new AttackingState() );
		this.machine.addState(new DeadState() );
	}

	void Update()
	{
		
	}
}
