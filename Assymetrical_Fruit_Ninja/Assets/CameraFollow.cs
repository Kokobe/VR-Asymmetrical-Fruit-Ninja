using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cube;
    Vector3 displacement;
    // Start is called before the first frame update
    void Start()
    {
        displacement = transform.position - cube.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cube.position + displacement;
        
    }
}
