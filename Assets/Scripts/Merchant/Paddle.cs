using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Merchant
{
	public class Paddle : MonoBehaviour 
	{
        public GameObject bullet;

        public float cooldown = 0.5f;

        private bool canFire = true;

		void Start()
		{
            
		}

        void Fire()
        {
            this.StartCoroutine(this.FireCoroutine());
        }

        IEnumerator FireCoroutine()
        {
            this.canFire = true;
            yield return new WaitForSeconds(this.cooldown);
        }
	}
}


