using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Merchant.Characters.Abilities.Base;

namespace Merchant.Characters.Abilities
{
    public class CharacterHealth : CharacterAbility
    {
        public int health = 0;

        public Action<Character> OnDeath;

        public int maxHealth = 10;

        private float invulnerabilityTimer = 0f;
        private bool isInvulnerable = false;

        private new Renderer renderer;

        protected override void Awake()
        {
            base.Awake();
            this.renderer = this.GetComponentInChildren<Renderer>();
        }

        protected void OnEnable()
        {
            this.health = this.maxHealth;
            this.renderer.material.SetFloat("_FlashAmount", 0);
        }

        public void TakeDamage(int damage)
        {
            if (this.isInvulnerable)
            {
                return;
            }
            
            this.health -= damage;

            this.StartCoroutine(this.Flash());

            if (this.health <= 0)
            {
                this.health = 0;
                this.StopAllCoroutines();

                if(this.OnDeath != null)
                {
                    this.OnDeath(this.character);
                }
            }
            else
            {
                this.StartCoroutine(this.InvulnerabilityTimer());
            }
        }

        private IEnumerator InvulnerabilityTimer()
        {
            this.isInvulnerable = true;

            yield return new WaitForSeconds(this.invulnerabilityTimer);

            this.isInvulnerable = false;
        }

        protected IEnumerator Flash()
        {
            this.renderer.material.SetFloat("_FlashAmount", 1);

            yield return new WaitForSeconds(0.1f);

            this.renderer.material.SetFloat("_FlashAmount", 0);
        }
    }   
}
