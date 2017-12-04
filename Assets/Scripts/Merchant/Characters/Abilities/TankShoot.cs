using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Merchant.Characters;
using Merchant.Characters.Abilities.Base;

public class TankShoot : AIAbility
{
    public bool isFiring = false;

    private float animationTimer = 0.55f;
    private float soundTimer = 0.5f;

    public float minTimeBetweenAttacks = 5.0f;
    public float maxTimeBetweenAttacks = 8.0f;

    public AudioClip clip;
    private AudioSource source;

    private bool canFire = true;

    public void Start()
    {
        this.source = this.GetComponent<AudioSource>();
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
        this.character.health.OnDeath -= HandleDeath;
        this.StopAllCoroutines();
    }

    private IEnumerator FireCoroutine()
    {
        this.canFire = false;
        this.isFiring = true;

        yield return new WaitForSecondsRealtime(soundTimer);
        this.source.PlayOneShot(this.clip);
        yield return new WaitForSecondsRealtime(animationTimer);
        this.character.attack.Pressed();
        this.character.attack.Released();

        this.isFiring = false;
        yield return new WaitForSecondsRealtime(Random.Range(minTimeBetweenAttacks, maxTimeBetweenAttacks));
        this.canFire = true;
    }
}
