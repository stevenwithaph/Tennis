using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Merchant.Characters.Abilities;

public class DamageOnTouch : MonoBehaviour
{
    public int damage = 0;

    void OnCollisionEnter(Collision collision)
    {
        CharacterHealth characterHealth = collision.gameObject.GetComponent<CharacterHealth>();
        if (characterHealth)
        {
            //characterHealth.TakeDamage(this.damage);
        }
    }
}