using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;

    private void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
    }

    public void ChangeScore(int value)
    {
        score += value;
        Debug.Log(score);
    }
}
