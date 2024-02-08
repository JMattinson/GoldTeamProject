using UnityEngine;
using UnityEngine.Events;

public class ConfigureRoom : MonoBehaviour
{
    public GameObject nWall, sWall, eWall, wWall, floor;
    public UnityEvent SwapEvent ;

    private int loopingNum;
    private GameObject[] currentMisc;

    //this is a funtion that can be called from anything
    public void setup(RoomData newRoom)//we can create room datas to quickly build new areas
    {
        foreach (var item in currentMisc)
        {
            Destroy(item);
        }
        SetWall(newRoom.nWall,nWall);
        SetWall(newRoom.eWall,eWall);
        SetWall(newRoom.sWall,sWall);
        SetWall(newRoom.wWall,wWall);
        SetWall(newRoom.floor,floor);
        loopingNum = 0;
        foreach (var item in newRoom.contentObjs)
        {
            //make sure that the objs in the first list match the transforms in the second list.
            currentMisc[loopingNum]=Instantiate(newRoom.contentObjs[loopingNum],newRoom.locations[loopingNum],new Quaternion(0,0,0,0));
            loopingNum++;
        }
    }
    
    public void SetWall(GameObject prefabb,GameObject Parentt)//creates an instance of the wall prefab as a child
    {//its easier to swap game objs than to change tex so the floor gets changed using this method too
        if (Parentt.transform.childCount!=0)
        {
            Destroy(Parentt.transform.GetChild(0));//clears out old wall
        }
        Instantiate(prefabb,Parentt.transform);//new wall as child
    }
    
    public void Start()
    {
        SwapEvent.Invoke();
    }
}
