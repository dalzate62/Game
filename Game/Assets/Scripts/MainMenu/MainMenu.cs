using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator anim;

    public void playerGame()
    {
        //Invocar trasicion de salida
        anim.SetTrigger("Start");
        StartCoroutine(loadLevel(1));
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public IEnumerator loadLevel(int buildIndex)
    {
        //esperar aque se ejecute
        yield return new WaitForSeconds(1);
        //cambio de esena
        SceneManager.LoadScene(buildIndex);
    }

}
