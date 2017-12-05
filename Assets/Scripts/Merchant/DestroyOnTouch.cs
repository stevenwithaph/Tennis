using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Merchant.Characters.Abilities;

public class DestroyOnTouch : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(this.transform.parent)
        {
            Destroy(this.transform.parent.gameObject);
        }

        Destroy(this.gameObject);
    }
}