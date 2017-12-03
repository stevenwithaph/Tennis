using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Merchant.Characters;

namespace Merchant.Characters.Abilities.Base
{
    public class CharacterAbility : MonoBehaviour
    {
        protected Character character;

        protected virtual void Awake()
        {
            this.character = this.GetComponent<Character>();
        }
    }
}
