using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMouse : MonoBehaviour
{
    private FacePosition face;

    void LookAtMouse()
    {
        Vector2 pos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint(pos);
        face.LookAt2D(pos);
    }

    // Use this for initialization
    void Start()
    {
        face = GetComponent<FacePosition>();
    }

    // Update is called once per frame
    void Update()
    {
        LookAtMouse();
    }
}
