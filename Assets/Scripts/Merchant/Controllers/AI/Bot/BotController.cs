using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prime31.StateKit;

public class BotController : AIController
{
    protected SKStateMachine<TankController> machine;

    void Update()
    {
        Vector3 direction = this.VectorToTarget();

		if(!this.IsInMinimumDistance())
		{
			this.character.movement.Direction = direction;
		}

        if (this.IsTargetInRange())
        {
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            this.character.attack.SetRotation(angle);
            this.character.attack.Pressed();
        }
    }
}
