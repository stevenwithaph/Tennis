using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBallsOnTouch : MonoBehaviour
{
	public int numberOfBalls = 4;

	public GameObject ball;

	private float randomAngle = 0.0f;

	void OnCollisionEnter()
	{
		randomAngle += Random.Range(0, 360);
		for(int i = 0; i < this.numberOfBalls; i++)
		{
			SpawnBall(i);
		}
	}

	void SpawnBall(int currentBallCount)
	{
		float finalSpread = (float)(this.numberOfBalls-1) / (float)this.numberOfBalls * 360 / 2;

        float spreadPiece = (float)currentBallCount / (float)this.numberOfBalls;
        float currentSpread = (spreadPiece * 360) - finalSpread + (randomAngle);

        Quaternion spreadRotation = Quaternion.LookRotation(Quaternion.Euler(0, currentSpread, 0) * this.transform.right);
		Vector3 spawnPosition = new Vector3(this.transform.position.x, 0.5f, this.transform.position.z);

		TrashMan.spawn(ball, spawnPosition, spreadRotation);
	}
}
