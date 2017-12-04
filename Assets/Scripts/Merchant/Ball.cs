using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Merchant
{
    public class Ball : MonoBehaviour
    {
        public int bouncesToDestroy = 4;

        public int currentBounces = 0;

        public Color enemyTint;

        public float stretch = 25.0f;

        private new Rigidbody rigidbody;

        private Vector3 direction;

        private float speed = 10;
        public float hitIncrease = 2.50f;

        public float initialSpeed = 10.0f;

        private LayerMask paddleLayer;
        private LayerMask wallLayer;
        private LayerMask enemyLayer;
        private LayerMask playerLayer;

        private LayerMask enemyBallLayer;
        private LayerMask playerBallLayer;

        void Awake()
        {
            this.rigidbody = this.GetComponent<Rigidbody>();

            this.paddleLayer = LayerMask.NameToLayer("Paddle");
            this.wallLayer = LayerMask.NameToLayer("Wall");
            this.enemyLayer = LayerMask.NameToLayer("Enemy");
            this.playerLayer = LayerMask.NameToLayer("Player");

            this.enemyBallLayer = LayerMask.NameToLayer("EnemyBall");
            this.playerBallLayer = LayerMask.NameToLayer("PlayerBall");
        }

        void OnEnable()
        {
            this.gameObject.layer = this.enemyBallLayer.value;
            this.GetComponentInChildren<SpriteRenderer>().color = this.enemyTint;

            this.AdjustSpeed(this.transform.forward, 10);
            
            this.speed = this.initialSpeed;
            this.currentBounces = 0;
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.gameObject.layer == this.wallLayer.value)
            {
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
            GameManager.instance.FreezeTime();

            this.gameObject.layer = this.playerBallLayer.value;
            this.GetComponentInChildren<SpriteRenderer>().color = Color.white;
            this.AdjustSpeed(direction, this.speed + this.hitIncrease);
        }

        void Bounce(Vector3 normal)
        {
            Vector3 newDirection = Vector3.Reflect(direction, normal);
            this.AdjustSpeed(newDirection, this.speed);
            this.CheckForDeath();
        }

        void AdjustSpeed(Vector3 direction, float speed)
        {
            this.rigidbody.velocity = direction * speed;
            this.speed = this.rigidbody.velocity.magnitude;
            this.direction = this.rigidbody.velocity.normalized;
        }

        void CheckForDeath()
        {
            this.currentBounces++;

            if(this.currentBounces == this.bouncesToDestroy)
            {
                TrashMan.despawn(this.gameObject);
            }
        }
    }
}


