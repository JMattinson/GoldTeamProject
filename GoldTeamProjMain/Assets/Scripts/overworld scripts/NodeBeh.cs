using UnityEngine;

public class NodeBeh : MonoBehaviour
{
    public GameObject[] dropPrefab;
    
    private GameObject drops;
    private Rigidbody bouncy;
    
    public void SpawnDrops(int dropNum)
    {//this code will spawn the specified number of drops slightly above the node, and launch them slightly
        //you can also add multiple types of drops and it will randomly choose one
        for (int x = 0; x < dropNum;)
        {
            drops = Instantiate(dropPrefab[Random.Range(0,dropPrefab.Length)],(transform.position+new Vector3(0,5,0)) ,new Quaternion(0f,(x*30f),0f,0f));
            bouncy=(Rigidbody)drops.GetComponentInChildren(typeof(Rigidbody));
            bouncy.velocity = new Vector3(10, 10, 0);
            x++;
        }
        Destroy(gameObject);
    }
}
