using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLootNew : MonoBehaviour
{
    public GameObject GenericPickup;
    //public GameObject HealthPickup;
    //public GameObject AmmoPickup;
    public GameObject CoinPickup;

    public void SpawnLoot(string magnitude)
    {
        float lootScalar = scaleLoot(magnitude);
        int randnum = 0;

        //GameObject GenericLoot = Instantiate(GenericPickup, transform.position, Quaternion.identity);
        //GiveToPlayer lootScript1 = GenericLoot.GetComponent<GiveToPlayer>();

        switch (randnum)
        {
            case 0:
                Debug.Log("Be health");
                GameObject HealthLoot = Instantiate(GenericPickup, transform.position, Quaternion.identity);
                GiveToPlayer lootScript2 = HealthLoot.GetComponent<GiveToPlayer>();
                lootScript2.value = randnum; // Assign pickup type
                lootScript2.amount = 50 * lootScalar;
                break;
            default:
                Debug.Log("Be points");
                GameObject PointsLoot = Instantiate(CoinPickup, transform.position, Quaternion.identity);
                GiveToPlayer lootScript3 = PointsLoot.GetComponent<GiveToPlayer>();
                lootScript3.value = randnum; // Assign pickup type
                lootScript3.amount = 50 * lootScalar;
                break;
        }

        //if (lootScript != null)
        //{
        //    float lootScalar = scaleLoot(magnitude);

        //    lootScript.value = randnum; // Assign pickup type
        //    switch (randnum)
        //    {
        //        case 0:
        //            Debug.Log("Be health");
        //            lootScript.amount = 50 * lootScalar;
        //            break;
        //        //////case 1:
        //        //////    Debug.Log("Be stamina");
        //        //////    lootScript.amount = 200 * lootScalar;
        //        //////    break;
        //        //////case 2:
        //        //////    Debug.Log("Be boost");
        //        //////    lootScript.amount = 10 * lootScalar;
        //        //////    break;
        //        //////case 3:
        //        //////    Debug.Log("Be ammo");
        //        //////    lootScript.amount = 10 * lootScalar;
        //        //////    break;
        //        default:
        //            Debug.Log("Be points");
        //            lootScript.amount = 25 * lootScalar;
        //            break;
        //    }

        //}
    }

    public float scaleLoot(string size)
    {
        if (size == "small")
        {
            return 0.5f;
        }
        else if (size == "big")
        {
            return 2f;
        }
        else return 1f;
    }
}
