using UnityEngine;
[CreateAssetMenu]
public class RoomData : ScriptableObject
{
    //holds data to quickly configure new rooms
    //look in the prefab base folder to find the style you want and then copy the prefab and customise it
    public GameObject nWall, sWall, eWall, wWall,floor;
    //make sure these two match up properly
    public GameObject[] contentObjs;
    // id recomend keeping they y val at 0 and then the x and z vals between 60-940
    public Vector3[] locations;
}
