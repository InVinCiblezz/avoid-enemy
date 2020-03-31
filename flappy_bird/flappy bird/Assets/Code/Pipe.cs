using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private Rigidbody2D RigidbodyPipe;
    private float min;
    private float max;
    private Transform _transform;

    // Start is called before the first frame update
    void Start()
    {
        //RigidbodyPipe = GetComponent<Rigidbody2D>();
        //RigidbodyPipe.velocity = new Vector2(0, 1);
        //_count = 0;
        _transform = GetComponent<Transform>();
        min= _transform.position.y;
        max= min + 5;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position =new Vector3(_transform.position.x, 
            Mathf.PingPong(Time.time*3,max-min)+min, _transform.position.z);

        //_count += 1;
        //if ((_count/60)%2 == 0)
       // {
         //   RigidbodyPipe.velocity = new Vector2(0, -RigidbodyPipe.velocity.y);
        //}
    }
}
