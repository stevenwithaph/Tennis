using System;
using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class Billboard : MonoBehaviour
{	
    private SpriteRenderer renderer;

    void Start()
    {
        this.renderer = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        this.transform.localRotation = Quaternion.Euler(
            45,
            -this.transform.parent.rotation.eulerAngles.y,
            -this.transform.parent.rotation.eulerAngles.y
        );
    }
}