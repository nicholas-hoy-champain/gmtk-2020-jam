using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Up,Down,Left,Right
}

public class DoorController : MonoBehaviour
{
    public Direction direction;
    public Vector2Int roomCoords;
    public Transform entrancePoint;
    Animator animator;
    RoomManager roomManager;
    bool hasEnemies;

    // Start is called before the first frame update
    void Start()
    {
        roomManager = GameObject.FindObjectOfType<RoomManager>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        hasEnemies = GameObject.FindGameObjectWithTag("Enemy") != null;
        animator.SetBool("Locked Down", hasEnemies);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!hasEnemies && collision.GetComponent<WizardController>() != null)
        {
            roomManager.UseDoor(this);
        }
    }
}
