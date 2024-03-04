using UnityEngine;
[CreateAssetMenu]
public class RoomData : ScriptableObject
{
    [Header("Holds data to quickly set up rooms")] //header adds a line of text in the editor
    public string roomName;
    public GameObject nWall, sWall, eWall, wWall,floor;
    
    [Header("add the objects you want to exist in the room")]
    [Header("make sure the number of the lists match")]
    [Tooltip("look in the prefab base folder to find the type of obj you want then create a prefab variant of that base and configure the variant")]
    public GameObject[] contentObjs;
    [Tooltip("id recomend Y val at 0. both x and z vals between 60-940")]
    public Vector3[] locations;
}
