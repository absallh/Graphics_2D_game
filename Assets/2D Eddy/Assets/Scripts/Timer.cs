using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public float TimeValue = 30f;
    public Text TimeText;
    public static Timer instance;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if (TimeValue > 0)
        {
            TimeValue -= Time.deltaTime;
        }
        else
        {
            TimeValue = 0;
        }
        DisplayTime(TimeValue);
    }


    void DisplayTime(float TimeToDisplay)
    {
        if (TimeToDisplay < 0)
        {

            TimeToDisplay = 0;

        }
        float Seconds = Mathf.FloorToInt(TimeToDisplay % 60);

        TimeText.text = string.Format("{0:00}", Seconds);
        if (TimeValue == 0)
        {
            SceneManager.LoadScene(2); //end menu index 
        }


    }





}
