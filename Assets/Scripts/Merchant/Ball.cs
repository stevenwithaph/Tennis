using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Merchant
{
    public class Ball : MonoBehaviour
    {
        private new Rigidbody rigidbody;

        private Vector3 direction;

        private float speed = 10;
        private float hitIncrease = 1f;

        private LayerMask paddleLayer;
        private LayerMask wallLayer;
        private LayerMask enemyLayer;
        private LayerMask playerLayer;

        void Start()
        {
            this.rigidbody = this.GetComponent<Rigidbody>();
            this.AdjustSpeed(Vector3.forward, 10);

            this.paddleLayer = LayerMask.NameToLayer("Paddle");
            this.wallLayer = LayerMask.NameToLayer("Wall");
            this.enemyLayer = LayerMask.NameToLayer("Enemy");
            this.playerLayer = LayerMask.NameToLayer("Player");
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.gameObject.layer == this.wallLayer.value)
            {
                Debug.Log(collision.contacts.Length);
                Debug.Log(collision.contacts[0].normal);
                this.Bounce(collision.contacts[0].normal);
            }
            else if (collision.collider.gameObject.layer == this.enemyLayer.value ||
                collision.collider.gameObject.layer == this.playerLayer)
            {
                Vector3 normal = this.transform.position - collision.collider.transform.position;
                normal.y = 0;
                normal.Normalize();
                this.Bounce(normal);
            }
        }

        void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.layer == this.paddleLayer.value)
            {
                Vector3 collisionDirection = this.transform.position - collider.transform.position;
                float angle = Mathf.Atan2(collisionDirection.x, collisionDirection.z) * Mathf.Rad2Deg;
                this.PaddleBounce(collider.transform.right, 0);
            }
        }

        void PaddleBounce(Vector3 direction, float distance)
        {
            this.AdjustSpeed(direction, this.speed + this.hitIncrease);
        }

        void Bounce(Vector3 normal)
        {
            Vector3 newDirection = Vector3.Reflect(direction, normal);
            this.AdjustSpeed(newDirection, this.speed);
        }

        void AdjustSpeed(Vector3 direction, float speed)
        {
            this.rigidbody.velocity = direction * speed;
            this.speed = this.rigidbody.velocity.magnitude;
            this.direction = this.rigidbody.velocity.normalized;
        }
    }
}


