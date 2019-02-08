using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFruit : MonoBehaviour
{
    public Transform central_aim;
    public Transform right_aim;
    public Transform left_aim;
    public float velocity = 10f;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print(Input.mouseScrollDelta);
        if (Input.GetMouseButtonDown(0))
        {
            var go = Instantiate(prefab, left_aim.position, Quaternion.identity);
            go.GetComponent<Rigidbody>().velocity = (central_aim.position - transform.position).normalized * velocity + GetComponent<Rigidbody>().velocity;
            Destroy(go, 8);

        }
        if (Input.GetMouseButtonDown(1))
        {
            var go = Instantiate(prefab, right_aim.position, Quaternion.identity);
            go.GetComponent<Rigidbody>().velocity = (central_aim.position - transform.position).normalized * velocity + GetComponent<Rigidbody>().velocity;
            Destroy(go, 8);

        }
    }
}
