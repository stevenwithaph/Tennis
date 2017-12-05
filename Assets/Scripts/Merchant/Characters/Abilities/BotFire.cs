using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Merchant.Characters.Abilities.Base;

namespace Merchant.Characters.Abilities
{
    public class BotFire : CharacterAbility
    {
        public float fireRate = 0.25f;
        public float timeBetweenRounds = 0.5f;
        public int roundsShot = 4;
        public int burstRounds = 3;

        public GameObject ball;
        public GameObject chargedBall;

        private int currentBurstRound = 0;

        public bool isSettingUp = false;
        public bool isFiring = false;
        public bool isChargedShot = false;

        public bool canFire = false;

        protected void OnEnable()
        {
            this.isSettingUp = false;
            this.isFiring = false;
            this.canFire = false;
            this.isChargedShot = false;
            this.currentBurstRound = 0;
        }

        protected void OnDisable()
        {
            this.StopAllCoroutines();
        }

        public void BeginFiring()
        {
            this.character.movement.PreventMovement();
            this.StartCoroutine(this.Setup());
        }

        IEnumerator Setup()
        {
            this.isSettingUp = true;
            yield return new WaitForSeconds(1.0f);
            this.StartCoroutine(this.Fire());
        }

        IEnumerator Fire()
        {
            this.isSettingUp = false;
            this.isFiring = true;
            for (int i = 0; i < this.burstRounds; i++)
            {
                for(int j = 0; j < this.roundsShot; j++)
                {
                    this.SpawnBall(this.ball);
                    yield return new WaitForSeconds(this.fireRate);
                }
                yield return new WaitForSeconds(this.timeBetweenRounds);
            }
            this.StartCoroutine(this.FireChargedShot());
        }

        IEnumerator FireChargedShot()
        {
            this.isChargedShot = true;
            yield return new WaitForSeconds(1.35f);
            this.SpawnBall(this.chargedBall);
            yield return new WaitForSeconds(1.65f);
            this.isChargedShot = false;
            this.character.movement.EnableMovement();
        }

        void SpawnBall(GameObject spawnBall)
        {
            Vector3 direction = this.character.attack.holder.transform.right;
            Vector3 position = this.transform.position;

            position.y = 0.5f;

            GameObject bullet = TrashMan.spawn(
                spawnBall,
                position,
                Quaternion.LookRotation(direction)
            );
        }
    }
}
