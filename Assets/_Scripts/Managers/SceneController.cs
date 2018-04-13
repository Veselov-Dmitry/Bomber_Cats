using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public static void Quit()
    {
        Application.Quit();
    }

    public static void ResetLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Start()
    {
        StopAllCoroutines();
        StartCoroutine(Temp());
    }

    IEnumerator Temp(){
        
        for (;;){
            yield return new WaitForSeconds(1f);
				int box = GameObject.FindGameObjectsWithTag("Box").Count();
				if (box <= 0)
				{
					//Settings.SpeedDown = 0.6f;
					//TODO increaseSpeedOfPlane when no boxes;
				}
        }
    }
}
