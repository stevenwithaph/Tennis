using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
	public float followSpeed = 10.0f;

	public Transform target;

    // Update is called once per frame
    void LateUpdate()
    {
		if(this.target)
		{
			Vector3 targetPosition = new Vector3(target.transform.position.x, 10, target.transform.position.z + -9f);
			this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, this.followSpeed * Time.deltaTime);
		}
    }
}
