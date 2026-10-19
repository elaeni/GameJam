using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoundaryCollision : MonoBehaviour
{
    public AudioSource Die;

    IEnumerator DelayLoadingLevel()
    {
        Debug.Log("Delay "+ (Die.clip.length));
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator DelayGameOver()
    {
        Debug.Log("Delay " + (Die.clip.length));
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene("GameOverScene");
    }

    public void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.CompareTag("Boundary"))
        {
            Leben.leben -= 1;
            Die.Play();
            if (Leben.leben == 0)
            {
                StartCoroutine(DelayGameOver());
            }
            else
            {
                //switch(lifes)
                switch (Leben.leben)
                {

                    case 2:
                        Debug.Log("C2");
                        StartCoroutine(DelayLoadingLevel());
                        break;
                    case 1:
                        Debug.Log("C1");
                        StartCoroutine(DelayLoadingLevel());
                        break;
                }
            }
        }
    }
}
