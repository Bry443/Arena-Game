using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;

    public static PlayerScore instance;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateScore(float amount)
    {
        _scoreText.text = amount + " Points";
    }
}
