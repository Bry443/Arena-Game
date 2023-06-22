using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ammo : MonoBehaviour
{
    [SerializeField]
    private Text _ammoText;

    public static ammo instance;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateAmmo(int count)
    {
        _ammoText.text = "Ammo: " + count;

    }
}
