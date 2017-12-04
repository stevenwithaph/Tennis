using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Merchant.Characters;

namespace Merchant.Controllers.Base
{
    public class Controller : MonoBehaviour
    {
        public Character character;

        public virtual void Posses(Character character)
        {
            this.character = character;
            this.character.owner = this;
        }

        public virtual void Unposses()
        {
            this.character.owner = null;
            this.character = null;
        }
    }   
}
