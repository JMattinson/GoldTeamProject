using UnityEngine;
[CreateAssetMenu]

public class playerInvent : ScriptableObject
{
   public float fuel, scrap, wood,wepDmg;

   public void addFuel(float amt)
   {
      fuel += amt;
   }

   public void addScrap(float amt)
   {
      scrap += amt;
   }

   public void addWood(float amt)
   {
      wood += amt;
   }

   public string report(string what)
   {
      string value = null;
      if (what=="fuel"||what=="Fuel")
      {
         value = fuel.ToString();
      }
      if (what=="scrap"||what=="Scrap")
      {
         value = scrap.ToString();
      }
      if (what=="wood"||what=="Wood")
      {
         value = wood.ToString();
      }
      return value;
   }

   public void newWepDmg(float newVal)
   {
      wepDmg = newVal;
   }

   public float dmgVal()
   {
      return wepDmg;
   }
}
