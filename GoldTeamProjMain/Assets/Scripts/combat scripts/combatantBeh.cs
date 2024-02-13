using System;
using UnityEngine;
using UnityEngine.Events;

public class combatantBeh : MonoBehaviour
{
    //kassidy you still need to go back and fix the enemies code
    
    //add this code to the being, an enemey the player etc. 
        //the weaapon will handle if it hits something or not. the weapon will need an action funtion
        //could be turning on a collider or launching a projectile
    
    public int maxHp, currentHp;
    public weaponSO myWeap;

    [Header("use this to give rewards for kill")]   //create a pref that shows up, drops goodies and dies
    public UnityEvent deathEv;
    [Header("use this to que up atk anim")]
    public UnityEvent attackEv;
    [Header("use this for when I get hit")]
    public UnityEvent dmgEv;

    private combatantBeh hitYou;
    private void Start()
    {
        currentHp = maxHp;
    }

    public void TakeDamage(int val)
    {
        // can add complex code here to change for atk dmg vs def etc.
        currentHp -= val;
        dmgEv.Invoke(); //this calls the health bar update
        if (currentHp <= 0)
        {
            deathEv.Invoke();
            Destroy(this.gameObject);
        }
    }
    
    private void attack(GameObject other)//the animation gets called from the obj, the weapon tells if it made contact
    {
        
        hitYou=other.gameObject.GetComponent<combatantBeh>();
        hitYou.TakeDamage(myWeap.Dmg);
    }
}
