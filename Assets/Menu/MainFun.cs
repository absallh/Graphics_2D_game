using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class MainFun : MonoBehaviour
{
 
    public void StartGame()
    {
        SceneManager.LoadScene("map_design");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    //for sound
    public AudioMixer Mix;
    public void SetVolume(float volume)
    {
        Mix.SetFloat("Mixer", volume);
    }

    
}
