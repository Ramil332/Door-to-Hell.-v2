// i made this scripts
// my blog https://t.me/+mswwKHfyTKM0MDky


using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class STARTGAME : MonoBehaviour
{
    public void playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Exit()
    {
        {
            Application.Quit();
        }
    }
    public void options()
    {
        SceneManager.LoadScene(4);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
