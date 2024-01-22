using UnityEngine;
[CreateAssetMenu]
public class RoomData : ScriptableObject
{
    //holds data to quickly configure new rooms
    //look in the prefab base folder to find the style you want and then copy the prefab and customise it
    public GameObject nWall, sWall, eWall, wWall,floor;
}
