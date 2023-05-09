using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotate : MonoBehaviour
{
    [Range(0, 500f)] public float speed = 5f;
    public Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(direction * speed * Time.deltaTime);
    }
}
