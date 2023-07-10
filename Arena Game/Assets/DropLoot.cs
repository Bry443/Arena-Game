using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLoot : MonoBehaviour
{
    public GameObject Pickup;
    public void SpawnLoot(string size)
    {
        GameObject lootObject = Instantiate(Pickup, transform.position, Quaternion.identity);
        GiveToPlayer lootScript = lootObject.GetComponent<GiveToPlayer>();
        if (lootScript != null)
        {
            float lootScalar = scaleLoot(size);

            int randnum = UnityEngine.Random.Range(0, 3);
            lootScript.value = randnum; // Assign pickup type
            switch (randnum)
            {
                case 0:
                    Debug.Log("Be health");
                    lootScript.amount = 50 * lootScalar;
                    break;
                case 1:
                    Debug.Log("Be stamina");
                    lootScript.amount = 200 * lootScalar;
                    break;
                case 2:
                    Debug.Log("Be boost");
                    lootScript.amount = 10 * lootScalar;
                    break;
                case 3:
                    Debug.Log("Be ammo");
                    lootScript.amount = 10 * lootScalar;
                    break;
            }

        }
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