using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Merchant.Characters.Abilities;

public class DamageByVelocity : MonoBehaviour
{
    public int minDamage = 0;
    public int maxDamage = 3;

    void OnCollisionEnter(Collision collision)
    {
        CharacterHealth characterHealth = collision.gameObject.GetComponent<CharacterHealth>();
        if (characterHealth)
        {
            characterHealth.TakeDamage(this.maxDamage);
        }
    }
}