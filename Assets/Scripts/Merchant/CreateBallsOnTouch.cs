﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBallsOnTouch : MonoBehaviour
{
	public int numberOfBalls = 4;

	public GameObject ball;

	void OnCollisionEnter()
	{
		for(int i = 0; i < this.numberOfBalls; i++)
		{
			SpawnBall(i);
		}
	}

	void SpawnBall(int currentBallCount)
	{
		float finalSpread = (float)(this.numberOfBalls-1) / (float)this.numberOfBalls * 360 / 2;

        float spreadPiece = (float)currentBallCount / (float)this.numberOfBalls;
        float currentSpread = (spreadPiece * 360) - finalSpread;

        Quaternion spreadRotation = Quaternion.LookRotation(Quaternion.Euler(0, currentSpread, 0) * this.transform.right);

		TrashMan.spawn(ball, this.transform.position, spreadRotation);
	}
}
