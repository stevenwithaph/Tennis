using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Merchant.Characters;

public class AIController : MonoBehaviour {

	protected Character player;
        
	protected void Awake()
	{
		GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
		if(playerGameObject)
		{
			this.player = playerGameObject.GetComponent<Character>();
		}
	}
}
