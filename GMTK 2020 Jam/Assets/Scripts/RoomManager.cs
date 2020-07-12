using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[System.Serializable]
public struct RoomData
{
    public Vector2Int coords;
    public bool spawned;
    public GameObject layout;
    public DoorController[] doors;
}

[System.Serializable]
public struct TierPairings
{
    public Vector2Int[] tierCoords;
    public List<GameObject> tierLayouts;
}

public class RoomManager : MonoBehaviour
{
    public RoomData[] rooms;

    public Vector2 startRoomPos;
    public Vector2 distanceBetweenRooms;

    public TierPairings[] tierPairings;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        PopulateRooms();
        Camera.main.transform.position = new Vector3(startRoomPos.x,startRoomPos.y, Camera.main.transform.position.z);
        EnterRoom(rooms[0], rooms[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PopulateRooms()
    {
        foreach(TierPairings tp in tierPairings)
        {
            foreach (Vector2Int coord in tp.tierCoords)
            {
                for (int i = 0; i < rooms.Length; i++)
                {
                    if(rooms[i].coords == coord)
                    {
                        int rnd = Random.Range(0, tp.tierLayouts.Count);
                        rooms[i].layout = tp.tierLayouts[rnd];
                        tp.tierLayouts.RemoveAt(rnd);
                        break;
                    }
                }
            }
        }
    }

    public void UseDoor(DoorController door)
    {
        RoomData newRoom = rooms[0], previousRoom = rooms[0];

        for (int i = 0; i < rooms.Length; i++)
        {
            if (rooms[i].coords == door.roomCoords)
            {
                previousRoom = rooms[i];
                break;
            }
        }

        Vector2Int newCoords = Vector2Int.zero;

        switch(door.direction)
        {
            case Direction.Down:
                newCoords = door.roomCoords + new Vector2Int(0, -1);
                break;
            case Direction.Up:
                newCoords = door.roomCoords + new Vector2Int(0, 1);
                break;
            case Direction.Right:
                newCoords = door.roomCoords + new Vector2Int(1, 0);
                break;
            case Direction.Left:
                newCoords = door.roomCoords + new Vector2Int(-1, 0);
                break;
        }

        for (int i = 0; i < rooms.Length; i++)
        {
            if (rooms[i].coords == newCoords)
            {
                newRoom = rooms[i];
                break;
            }
        }

        EnterRoom(newRoom, previousRoom);
    }

    public void EnterRoom(RoomData newRoom, RoomData previousRoom)
    {
        Vector2 newCameraPos = ((newRoom.coords) * distanceBetweenRooms) + startRoomPos;
        Camera.main.transform.position = new Vector3(newCameraPos.x, newCameraPos.y, Camera.main.transform.position.z);

        //Spawn Player At Door
        if(newRoom.coords.x > previousRoom.coords.x)
        {
            foreach(DoorController door in newRoom.doors)
            {
                if (door.direction == Direction.Left)
                {
                    player.transform.position = door.entrancePoint.position;
                    break;
                }
            }
        }
        else if (newRoom.coords.x < previousRoom.coords.x)
        {
            foreach (DoorController door in newRoom.doors)
            {
                if (door.direction == Direction.Right)
                {
                    player.transform.position = door.entrancePoint.position;
                    break;
                }
            }
        }
        else if (newRoom.coords.y > previousRoom.coords.y)
        {
            foreach (DoorController door in newRoom.doors)
            {
                if (door.direction == Direction.Down)
                {
                    player.transform.position = door.entrancePoint.position;
                    break;
                }
            }
        }
        else if (newRoom.coords.y < previousRoom.coords.y)
        {
            foreach (DoorController door in newRoom.doors)
            {
                if (door.direction == Direction.Up)
                {
                    player.transform.position = door.entrancePoint.position;
                    break;
                }
            }
        }

        if (!newRoom.spawned)
        {
            Instantiate(newRoom.layout, Camera.main.transform.position, Camera.main.transform.rotation);
            newRoom.spawned = true;
        }
    }
}
