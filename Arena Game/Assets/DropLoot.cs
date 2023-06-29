using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLoot : MonoBehaviour
{
    public GameObject Pickup;
    public void SpawnLoot()
    {
        GameObject lootObject = Instantiate(Pickup, transform.position, Quaternion.identity);
        GiveToPlayer lootScript = lootObject.GetComponent<GiveToPlayer>();
        if (lootScript != null)
        {
            int randnum = UnityEngine.Random.Range(0, 3);
            switch (randnum)
            {
                case 0:
                    Debug.Log("Be health");
                    lootScript.value = 0;
                    lootScript.amount = 20;
                    break;
                case 1:
                    Debug.Log("Be stamina");
                    lootScript.value = 1;
                    lootScript.amount = 20;
                    break;
                case 2:
                    Debug.Log("Be boost");
                    lootScript.value = 2;
                    lootScript.amount = 10;
                    break;
                case 3:
                    Debug.Log("Be ammo");
                    lootScript.value = 3;
                    lootScript.amount = 10;
                    break;
            }

        }
    }
}