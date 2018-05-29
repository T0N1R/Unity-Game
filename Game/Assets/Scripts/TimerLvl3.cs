using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*
 * Clase para controlar el tiempo de juego en el nivel Facil
 */

public class TimerLvl3 : MonoBehaviour
{
    public string levelToLoad;
    public int timeLeft = 30;//tiempo
    public Text countdownText;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("LoseTime");
    }

    // Update is called once per frame
    void Update()
    {
        countdownText.text = ("Time Left: " + timeLeft);

        if (timeLeft <= 0)
        {
            //Application.LoadLevel(levelToLoad);

            StopCoroutine("LoseTime");
            countdownText.text = "Times Up!";
            //Cambio de escena
            if (GameController.instance.gameOver != true)
            {
                SceneManager.LoadScene("Win", LoadSceneMode.Single);
            }
        }

        if(GameController.instance.gameOver == true)
        {
            countdownText.text = "";
        }
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}