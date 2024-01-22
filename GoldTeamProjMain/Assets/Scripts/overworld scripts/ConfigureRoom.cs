using UnityEngine;
using UnityEngine.Events;

public class ConfigureRoom : MonoBehaviour
{
    public GameObject nWall, sWall, eWall, wWall, floor;

    public void setup(RoomData newRoom)//we can create room datas to quickly build new areas
    {
        SetWall(newRoom.nWall,nWall);
        SetWall(newRoom.eWall,eWall);
        SetWall(newRoom.sWall,sWall);
        SetWall(newRoom.wWall,wWall);
        SetWall(newRoom.floor,floor);
    }
    public void SetWall(GameObject prefabb,GameObject Parentt)//creates an instance of the wall prefab as a child
    {//its easier to swap game objs than to change tex so the floor gets changed using this method too
        if (Parentt.transform.childCount!=0)
        {
            Destroy(Parentt.transform.GetChild(0));//clears out old wall
        }
        Instantiate(prefabb,Parentt.transform);//new wall as child
    }
    
    public UnityEvent SwapEvent ;

    public void Start()
    {
        SwapEvent.Invoke();
    }
}
