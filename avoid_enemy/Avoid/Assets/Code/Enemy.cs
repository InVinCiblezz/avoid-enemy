using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{

    protected Rigidbody2D rigidBody;
    public float RandomDirection;
    public float v1 = 3;
    public float v2 = 3;
    public static float TimeScale { get; private set; }
    public static void Die () { TimeScale = 0f; }
    public static void On () { TimeScale = 1f; }
       // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();       
        GetRandomDirection();
        rigidBody.velocity = new Vector2(v1, v2);
        On();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var x = 5 + rigidBody.velocity.x;
        var y = 5 + rigidBody.velocity.y;
        rigidBody.velocity = new Vector2(-x, -y);
    }

    private void GetRandomDirection()
    {
        switch (RandomDirection % 4)
        {
            case 1:
                v1 = Math.Abs(v1);
                break;
            case 2:
                v2 = -Math.Abs(v2);
                break;
            case 3:
                v1 = -Math.Abs(v1);
                break;
            default:
                v2 = Math.Abs(v2);
                break;
        }
        RandomDirection += 1;
    }

    // Update is called once per frame
    internal void Update()
    {
        var x = rigidBody.velocity.x * TimeScale;
        var y = rigidBody.velocity.y * TimeScale;
        var screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.x < -10||screenPosition.x > Screen.width + 10)
            rigidBody.velocity = new Vector2(-x, y);
        else if (screenPosition.y < -10||screenPosition.y > Screen.height + 10)
            rigidBody.velocity = new Vector2(x, -y);

    }
}
