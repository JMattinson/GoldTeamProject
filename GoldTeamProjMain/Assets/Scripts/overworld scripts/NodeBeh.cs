using UnityEngine;

public class NodeBeh : MonoBehaviour
{
    public GameObject[] dropPrefab;
    
    private GameObject drops;
    private Rigidbody bouncy;
    
    public void SpawnDrops(int dropNum)
    {//this code will spawn the specified number of drops slightly above the node, and launch them slightly
        //you can also add multiple types of drops and it will randomly choose one
        for (int i = 0; i < dropNum;)
        {   //list of possible drops from this pref     choose random from list                     spawn from top of obj          change the angle it shoots out at diff angle each time
            drops = Instantiate(dropPrefab[Random.Range(0,dropPrefab.Length)],(transform.position+new Vector3(0,5,0)) ,new Quaternion((i*60f),(i*60f),(i*60f),0f));
            bouncy=(Rigidbody)drops.GetComponentInChildren(typeof(Rigidbody));
            bouncy.velocity = new Vector3(10, 10, 0);//launch so it arcs
            i++;
        }
        Destroy(gameObject);
    }
}
