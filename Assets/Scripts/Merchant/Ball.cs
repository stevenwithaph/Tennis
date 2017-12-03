using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Merchant
{
	public class Ball : MonoBehaviour 
	{
		private new Rigidbody2D rigidbody;

		private Vector2 direction;

		private float speed = 10;
		private float hitIncrease = 0.1f;

		private LayerMask paddleLayer;

		void Start()
		{
			this.rigidbody = this.GetComponent<Rigidbody2D>();
			this.AdjustSpeed(Vector2.up, 10);

			this.paddleLayer = LayerMask.NameToLayer("Paddle");
		}

		void OnCollisionEnter2D(Collision2D collison)
		{
			this.Bounce(collison.contacts[0].normal);
		}

		void OnTriggerEnter2D(Collider2D collider)
		{
			Vector2 collisionDirection = this.transform.position - collider.transform.position;
			float angle = Mathf.Atan2(collisionDirection.y, collisionDirection.x) * Mathf.Rad2Deg;

			this.PaddleBounce(collider.transform.right, 0);
		}

		void PaddleBounce(Vector2 direction, float distance)
		{
			this.AdjustSpeed(direction, this.speed + this.hitIncrease);
		}

		void Bounce(Vector2 normal)
		{
			Vector2 newDirection = Vector2.Reflect(direction, normal);
			this.AdjustSpeed(newDirection, this.speed);
		}

		void AdjustSpeed(Vector2 direction, float speed)
		{
			this.rigidbody.velocity = direction * speed;
			this.speed = this.rigidbody.velocity.magnitude;
			this.direction = this.rigidbody.velocity.normalized;
		}
	}
}


