using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected Rigidbody2D rigidBody;
    /// <summary>
    /// How fast we move
    /// </summary>
    private float MovingSpeed = 10;

    internal void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            rigidBody.velocity = new Vector2(0, MovingSpeed);
        else if (Input.GetKey(KeyCode.DownArrow))
            rigidBody.velocity = new Vector2(0, -MovingSpeed);
        else if (Input.GetKey(KeyCode.LeftArrow))
            rigidBody.velocity = new Vector2(-MovingSpeed, 0);
        else if (Input.GetKey(KeyCode.RightArrow))
            rigidBody.velocity = new Vector2(MovingSpeed, 0);
        else {
            rigidBody.velocity = new Vector2(0, 0);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(0, 0);
    }


    internal void Update()
    {
        //Debug.Log(rigidBody.velocity);
        // Check for screen wrap
        Camera mainCamera = Camera.main;
        //var mainCamera = Camera.main;
        if (mainCamera)
        {
            var worldPosition = transform.position;
            var screenPosition = mainCamera.WorldToScreenPoint(worldPosition);
            var screenMin = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0));
            var screenMax = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

            if (screenPosition.x < -5)
            {
                worldPosition.x = screenMax.x;
                rigidBody.MovePosition(worldPosition);
            }

            if (screenPosition.x > Screen.width+5)
            {
                worldPosition.x = screenMin.x;
                rigidBody.MovePosition(worldPosition);
            }

            if (screenPosition.y < -5)
            {
                worldPosition.y = screenMax.y;
                rigidBody.MovePosition(worldPosition);
            }

            if (screenPosition.y > Screen.height+5)
            {
                worldPosition.y = screenMin.y;
                rigidBody.MovePosition(worldPosition);
            }

        }
    }
}
