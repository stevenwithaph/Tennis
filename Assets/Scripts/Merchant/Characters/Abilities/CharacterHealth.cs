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
        public Action<Character> OnHurt;

        public int maxHealth = 2;

        public bool freezeTimeOnHit = false;

        private AudioSource source;

        public AudioClip hurt;

        private new Renderer renderer;

        protected override void Awake()
        {
            base.Awake();
            this.source = this.GetComponent<AudioSource>();
            this.renderer = this.GetComponentInChildren<Renderer>();
        }

        protected void OnEnable()
        {
            this.health = this.maxHealth;
            this.renderer.material.SetFloat("_FlashAmount", 0);
        }

        public void TakeDamage(int damage)
        {
            if (this.freezeTimeOnHit)
            {
                GameManager.instance.FreezeTime();
            }

            if(this.OnHurt != null)
            {
                this.OnHurt(this.character);
            }

            if (this.hurt)
            {
                this.source.PlayOneShot(this.hurt);
            }
            this.health -= damage;

            if (this.health <= 0)
            {
                this.health = 0;
                this.StopAllCoroutines();

                if (this.OnDeath != null)
                {
                    this.OnDeath(this.character);
                }
            }
            else
            {
                this.StartCoroutine(this.Flash());
            }
        }

        protected IEnumerator Flash()
        {
            this.renderer.material.SetFloat("_FlashAmount", 1);

            yield return new WaitForSecondsRealtime(0.1f);

            this.renderer.material.SetFloat("_FlashAmount", 0);
        }
    }
}
