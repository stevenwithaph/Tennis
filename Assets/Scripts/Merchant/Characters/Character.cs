using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Merchant.Characters.Abilities;

namespace Merchant.Characters
{
    [RequireComponent(typeof(CharacterDirection))]
    [RequireComponent(typeof(CharacterMovement))]
    [RequireComponent(typeof(CharacterAttack))]
    [RequireComponent(typeof(CharacterHealth))]
    public class Character : MonoBehaviour
    {
        [NonSerialized]
        public CharacterDirection direction;
        [NonSerialized]
        public CharacterMovement movement;
        [NonSerialized]
        public CharacterAttack attack;
        [NonSerialized]
        public CharacterHealth health;

        private void Awake()
        {
            this.direction = this.GetComponent<CharacterDirection>();
            this.movement = this.GetComponent<CharacterMovement>();
            this.attack = this.GetComponent<CharacterAttack>();
            this.health = this.GetComponent<CharacterHealth>();
        }
    }
}
