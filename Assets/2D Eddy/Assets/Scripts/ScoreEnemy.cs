using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreEnemy : MonoBehaviour
{
    public Text MyScoreText;
    public int ScoreNum;
    public static ScoreEnemy instance;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        ScoreNum = 0;
        MyScoreText.text = " " + ScoreNum;

    }

    // Update is called once per frame
    public void AddPoint()
    {

        ScoreNum += 1;
        MyScoreText.text = " " + ScoreNum;
       

    }

}

