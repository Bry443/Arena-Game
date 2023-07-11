using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;

    public static PlayerScore instance;

    public float currentScore;

    public void Awake()
    {
        instance = this;
    }

    public void UpdateScore(float amount)
    {
        currentScore += amount;
        _scoreText.text = currentScore + " Points";
    }

    public float getScore()
    {
        return currentScore;
    }
}
