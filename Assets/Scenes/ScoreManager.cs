using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text scorer;
    int value = 25;
    public void Score()
    {
        if(value==0)
        {

        }
        value--;
        scorer.text = "Remaining Coins:" + value;
    }
}
