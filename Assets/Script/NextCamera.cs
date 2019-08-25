using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextCamera : MonoBehaviour
{
    public Transform target;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = new Vector3(transform.position.x, transform.position.y * 0.2f, transform.position.z);
        //transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
        //transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
    }
}
