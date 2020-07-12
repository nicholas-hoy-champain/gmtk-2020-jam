using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TurnOn()
    {
        GetComponent<PolygonCollider2D>().enabled = true;
    }
}
