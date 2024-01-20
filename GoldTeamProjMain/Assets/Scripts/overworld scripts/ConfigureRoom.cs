using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class ConfigureRoom : MonoBehaviour
{
    public GameObject nWall, sWall, eWall, wWall, floor;

    public void SetWall(GameObject prefabb,GameObject Parentt)
    {
        Instantiate(prefabb,Parentt.transform);
    }

    //public void SetFloor(Material newMat) { }

    public void setup(RoomData newRoom)
    {
        SetWall(newRoom.nWall,nWall);
        SetWall(newRoom.eWall,eWall);
        SetWall(newRoom.sWall,sWall);
        SetWall(newRoom.wWall,wWall);
        //SetFloor(newroom.floorTex);
    }

    public UnityEvent testEvent ;

    public void Start()
    {
        testEvent.Invoke();
    }
}
