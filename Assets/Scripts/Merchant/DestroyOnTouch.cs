using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Merchant.Characters.Abilities;

public class DestroyOnTouch : MonoBehaviour
{
    public int damage = 0;

    void OnCollisionEnter(Collision collision)
    {
        if(this.transform.parent)
        {
            Destroy(this.transform.parent.gameObject);
        }

        Destroy(this.gameObject);
    }
}