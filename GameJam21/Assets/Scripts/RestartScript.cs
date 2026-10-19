using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    //public AudioSource Die;

    IEnumerator DelayLoadingLevel()
    {
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator DelayGameOver()
    {
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene("GameOverScene");
    }

    public void Restart()
    {
        //Die.Play();
        if (Leben.leben > 1)
        {
            Leben.leben -= 1;
            StartCoroutine(DelayLoadingLevel());
        }
        else
        {
            StartCoroutine(DelayGameOver());
        }
    }
}
