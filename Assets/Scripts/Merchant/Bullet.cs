using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(DamageOnTouch))]
public class Bullet : MonoBehaviour
{
    public float speed;

    private new Rigidbody rigidbody;

    // Use this for initialization
    void Start()
    {
        this.rigidbody = this.GetComponent<Rigidbody>();
        this.rigidbody.velocity = this.transform.forward * speed;
    }

    public void SetDamage(int damage)
    {
        this.GetComponent<DamageOnTouch>().damage = damage;
    }
}