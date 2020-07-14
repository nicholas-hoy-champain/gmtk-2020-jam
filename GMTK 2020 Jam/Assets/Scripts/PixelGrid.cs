using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelGrid : MonoBehaviour
{
    [SerializeField]

    private int pixelsPerUnit = 16;

    private Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        Vector3 newLocalPosition = Vector3.zero;

        newLocalPosition.x = (Mathf.Round(parent.position.x * pixelsPerUnit) / pixelsPerUnit) - parent.position.x;
        newLocalPosition.y = (Mathf.Round(parent.position.y * pixelsPerUnit) / pixelsPerUnit) - parent.position.y;

        transform.localPosition = newLocalPosition;
    }
}
