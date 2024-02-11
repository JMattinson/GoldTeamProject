using UnityEngine;

public class NodeBeh : MonoBehaviour
{
    [Tooltip("add in any drops that can come from this")]
    public GameObject[] dropPrefab;
    [Header("pls dont touch it will break the clones")]
    public GameObject parent;
    
    [Tooltip("player is 20-ish tall")]
    public float spawnHeight; 
    
    private GameObject drops;
    private Rigidbody bouncy;
    
    //make sure the resourse node visuals have collison so the player cant walk through it.
    
    public void SpawnDrops(int dropNum)
    {//this code will spawn the specified number of drops slightly above the node, and launch them slightly
        //you can also add multiple types of drops and it will randomly choose one
        for (int i = 0; i < dropNum;)
        {
            //list of possible drops from this pref     choose random from list                     spawn from top of obj                           doesnt matter
            drops = Instantiate(dropPrefab[Random.Range(0,dropPrefab.Length)],(transform.position+new Vector3(0,spawnHeight,0)) ,new Quaternion(0,0,0,0));
            bouncy=(Rigidbody)drops.GetComponentInChildren(typeof(Rigidbody));
            bouncy.velocity = new Vector3(Random.Range(-20,20), 0, Random.Range(-20,20));//launch at rand angle, rigidbody will then fall with gravity
            i++;
        }
        Destroy(parent);//setting it to a reference of itself vs just doing gameObject helps it not destroy all the clones
    }
}
