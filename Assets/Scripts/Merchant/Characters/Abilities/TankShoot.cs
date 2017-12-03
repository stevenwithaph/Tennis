using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Merchant.Characters;
using Merchant.Characters.Abilities.Base;

public class TankShoot : AIAbility
{
    public bool isFiring = false;

    public float animationTimer = 1.05f;

    public void Fire()
    {
        if (!this.isFiring)
        {
            this.StartCoroutine(this.FireCoroutine());
        }
    }

    private IEnumerator FireCoroutine()
    {
        this.isFiring = true;
        yield return new WaitForSeconds(animationTimer);
        this.character.attack.Pressed();
        this.character.attack.Released();

        this.isFiring = false;
    }
}
