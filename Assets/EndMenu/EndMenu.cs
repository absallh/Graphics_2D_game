using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndMenu : MonoBehaviour
{
    // Start is calledbefore the first frame update
    public GameObject White;
    public GameObject Black;
    public GameObject Equal;

    public void Home()
    {
        SceneManager.LoadScene(0); // main menu index
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        if (Timer.instance.TimeValue == 0)
        {
            if (Score.instance.ScoreNum > ScoreEnemy.instance.ScoreNum)
            {
                White.SetActive(true);
                Black.SetActive(false);
                Equal.SetActive(false);

            }
            else if (ScoreEnemy.instance.ScoreNum > Score.instance.ScoreNum)
            {

                Black.SetActive(true);
                White.SetActive(false);
                Equal.SetActive(false);
            }
            else
            {
                Equal.SetActive(true);
                Black.SetActive(false);
                White.SetActive(false);

            }

        }
    }
}

