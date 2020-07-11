using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePosition : MonoBehaviour
{

    public float AngleFromFace2D(Vector2 pos)
    {
        Vector2 direction = new Vector2(pos.x - transform.position.x, pos.y - transform.position.y);
        float facingAngle = Mathf.Atan(direction.y / direction.x) / Mathf.PI * 180.0f;
        if (direction.x > 0)
        {
            facingAngle = (facingAngle + 180);
            if (facingAngle > 180)
            {
                facingAngle = -360 + facingAngle;
            }
        }
        return facingAngle;
    }

    public float AngleToFace2D(Vector2 pos)
    {
        Vector2 direction = new Vector2(transform.position.x - pos.x, transform.position.y - pos.y);
        float facingAngle = Mathf.Atan(direction.y / direction.x) / Mathf.PI * 180.0f;
        if (direction.x > 0)
        {
            facingAngle = (facingAngle + 180);
            if (facingAngle > 180)
            {
                facingAngle = -360 + facingAngle;
            }
        }
        return facingAngle;
    }

    public void LookAt2D(Vector2 pos)
    {
        float facingAngle = AngleToFace2D(pos);
        transform.rotation = Quaternion.Euler(0, 0, facingAngle);
    }
}
