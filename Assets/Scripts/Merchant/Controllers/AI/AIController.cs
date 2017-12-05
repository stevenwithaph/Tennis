using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Merchant.Characters;
using Merchant.Controllers.Base;

public class AIController : Controller
{
    protected Character player;

    public float attackRange = 10.0f;
    public float minimumDistance = 5.0f;

    protected Vector3 VectorToTarget()
    {
        return (this.player.transform.position - this.character.transform.position).normalized;
    }

    protected bool IsTargetInRange()
    {
        return (Vector3.Distance(this.player.transform.position, this.character.transform.position) <= this.attackRange);
    }

	protected float AngleToTarget()
	{
		Vector3 direction = this.VectorToTarget();

		return Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
	}

    protected bool IsInMinimumDistance()
    {
        return (Vector3.Distance(this.player.transform.position, this.character.transform.position) <= this.minimumDistance);
    }

    public override void Posses(Character character)
    {
        base.Posses(character);
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        if (playerGameObject)
        {
            this.player = playerGameObject.GetComponent<Character>();
        }
    }

    public override void Unposses()
    {
        base.Unposses();
    }
}
