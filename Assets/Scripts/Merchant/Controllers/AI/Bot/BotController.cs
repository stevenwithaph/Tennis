using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prime31.StateKit;

using Merchant.Characters;
using Merchant.Characters.Abilities;

public class BotController : AIController
{
    private BotFire botFire;

    public override void Posses(Character possessing)
    {
        base.Posses(possessing);
        this.botFire = this.character.GetComponent<BotFire>();
    }

    protected void Update()
    {
        Vector3 direction = this.VectorToTarget();

        if (this.character.movement.canMove)
        {
            if (!this.IsInMinimumDistance())
            {
                this.character.movement.Direction = direction;
            }
            else
            {
                this.character.movement.Direction = Vector3.zero;
                this.botFire.BeginFiring();
            }
        }

        this.character.attack.SetRotation(this.AngleToTarget() - 90.0f);
    }
}

