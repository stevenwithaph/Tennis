using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
	public float rotationSpeed = 10.0f;
    
    void Update()
    {
		Vector3 rotation = this.transform.rotation.eulerAngles;
		rotation.y += rotationSpeed * Time.deltaTime;
		this.transform.rotation = Quaternion.Euler(rotation);
    }
}
