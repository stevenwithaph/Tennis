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
    public class Character : MonoBehaviour
    {
        [NonSerialized]
        public CharacterDirection direction;
        [NonSerialized]
        public CharacterMovement movement;
        [NonSerialized]
        public CharacterAttack attack;

        private void Start()
        {
            this.direction = this.GetComponent<CharacterDirection>();
            this.movement = this.GetComponent<CharacterMovement>();
            this.attack = this.GetComponent<CharacterAttack>();
        }
    }
}
