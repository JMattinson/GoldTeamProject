using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConfigureRoom : MonoBehaviour
{
    public GameObject nWall, sWall, eWall, wWall, floor;
    public UnityEvent SwapEvent ;

    private int loopingNum;
    public List<GameObject> currentMisc;

    //this is a funtion that can be called from anything
    public void setup(RoomData newRoom)//we can create room datas to quickly build new areas
    {
        foreach (var thingy in currentMisc)
        {
            Destroy(thingy.gameObject);
        }
        currentMisc.Clear();//idk if this is needed but it makes me feel better
        SetWall(newRoom.nWall,nWall);
        SetWall(newRoom.eWall,eWall);
        SetWall(newRoom.sWall,sWall);
        SetWall(newRoom.wWall,wWall);
        SetWall(newRoom.floor,floor);
        loopingNum = 0;
        foreach (var item in newRoom.contentObjs)
        {
            //make sure that the objs in the first list match the transforms in the second list.
            currentMisc.Add(Instantiate(newRoom.contentObjs[loopingNum],newRoom.locations[loopingNum],new Quaternion(0,0,0,0)));
            loopingNum++;//kassidy stop being an idiot and trying to take this out, it wont work
        }
    }

    private void SetWall(GameObject prefabb,GameObject Parentt)//creates an instance of the wall prefab as a child
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
