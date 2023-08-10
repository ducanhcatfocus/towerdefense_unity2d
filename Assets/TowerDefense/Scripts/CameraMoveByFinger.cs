using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Horizontal,
    Vertial
}

public class CameraMoveByFinger : MonoBehaviour
{
    public Direction direction = Direction.Vertial;
    public Vector3 firstPoint;
    public Vector3 secondPoint;
    public float speedMove;

    // Update is called once per frame
    void Update()
    {
        Processing();
    }

    public void Processing()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPoint = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            secondPoint = Input.mousePosition;

            var direction = secondPoint - firstPoint;
            direction.Normalize();

            if (this.direction == Direction.Horizontal)
            {
                direction.y = 0; // (x, 0, 0) v3.left
            }
            else
            {
                direction.x = 0;
            }

            direction.z = 0;
            transform.position += -direction * Time.deltaTime * speedMove;
        }
    }
}
