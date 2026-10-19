using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScript : MonoBehaviour
{
    public AudioSource Portal;

    IEnumerator DelayLoadingLevel()
    {
        yield return new WaitForSeconds(.55f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.CompareTag("Finish"))
        {
            Portal.Play();
            StartCoroutine(DelayLoadingLevel());
        }        
    }
}
