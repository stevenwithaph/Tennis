using System;
using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class Billboard : MonoBehaviour
{	
    void Update()
    {
        this.transform.localRotation = Quaternion.Euler(
            45,
            -this.transform.parent.rotation.eulerAngles.y,
            -this.transform.parent.rotation.eulerAngles.y
        );
    }
}