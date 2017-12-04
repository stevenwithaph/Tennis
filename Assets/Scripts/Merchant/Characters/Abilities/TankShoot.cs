using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Merchant.Characters;
using Merchant.Characters.Abilities.Base;

public class TankShoot : AIAbility
{
    public bool isFiring = false;

    public float animationTimer = 1.05f;

    public float minTimeBetweenAttacks = 5.0f;
    public float maxTimeBetweenAttacks = 8.0f;

    private bool canFire = true;

    public void Start()
    {
        this.character.health.OnDeath += HandleDeath;
    }

    public void OnEnable()
    {
        this.isFiring = false;
        this.canFire = true;
    }

    public void Fire()
    {
        if (this.canFire)
        {
            this.StartCoroutine(this.FireCoroutine());
        }
    }

    private void HandleDeath(Character character)
    {
        this.StopAllCoroutines();
    }

    private IEnumerator FireCoroutine()
    {
        this.isFiring = true;
        this.canFire = false;
        yield return new WaitForSeconds(animationTimer);
        this.character.attack.Pressed();
        this.character.attack.Released();

        this.isFiring = false;

        yield return new WaitForSeconds(Random.Range(minTimeBetweenAttacks, maxTimeBetweenAttacks));
        this.canFire = true;
    }
}
