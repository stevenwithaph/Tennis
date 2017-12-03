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
            Debug.Log(this.character);
        }

        public virtual void Unposses()
        {
            this.character = null;
        }
    }   
}
