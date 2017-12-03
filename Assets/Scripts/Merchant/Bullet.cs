using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(DamageOnTouch))]
public class Bullet : MonoBehaviour
{
    public float speed;

	public float lifetime;

    private new Rigidbody2D rigidbody;

    // Use this for initialization
    void Start()
    {
        this.rigidbody = this.GetComponent<Rigidbody2D>();
        this.rigidbody.velocity = this.transform.right * speed;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(this.gameObject);
    }

    public void SetDamage(int damage)
    {
        this.GetComponent<DamageOnTouch>().damage = damage;
    }
}