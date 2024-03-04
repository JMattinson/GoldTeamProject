using UnityEngine;
[CreateAssetMenu]

public class playerInvent : ScriptableObject
{
   public int fuel, scrap, wood,wepDmg;

   //simplify the code for changing vals, can i have one funtion handel all of them?
      //maybe a funtion that accepts a string and then read it as (name,value)

   public void addFuel(int amt)
   {
      fuel += amt;
   }

   public void addScrap(int amt)
   {
      scrap += amt;
   }

   public void addWood(int amt)
   {
      wood += amt;
   }

   public string reportRes(string what)
   {
      string value = null;//local variable so we can respond with something
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
   
}
