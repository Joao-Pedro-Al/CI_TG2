using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GamePlayer : MonoBehaviour
{
    private int difi = GameManager.DifiAtual();

    [Range(0, 2)]
    [SerializeField]
    private int timer;

    /*switch(difi){
        case 0:
            timer = 3;
            break;

        case 1:
            timer = 2;
            break;
        
        case 2:
            timer = 1;
            break;
    }*/

    [Range(0, 30)]
    [SerializeField]
    private int matchTimer;

    [SerializeField]
    private List<GameObject> listBrocolos;

    [SerializeField]
    private TMP_Text timerText;

    private float currentTimer;

    private System.Random randomNumberGenerator;

    void Start()
    {
        randomNumberGenerator = new System.Random();
        currentTimer = 0;
        StartCoroutine(ChangeVegetal());
    }

    void Update()
    {
        if(currentTimer > matchTimer)
        {
            SceneManager.LoadScene("FinalSceneWhackAMole");
        }

        if(GameManager.Resultado() < 0)
        {
            SceneManager.LoadScene("FinalSceneWhackAMole");
        }

        currentTimer += Time.deltaTime;

        float NumberOfSeconds = matchTimer - currentTimer;
        float seconds = Mathf.FloorToInt(NumberOfSeconds % 60);
        timerText.text = $"{seconds:00}";
    }

    IEnumerator ChangeVegetal()
    {
        while (currentTimer < matchTimer)
        {
            yield return new WaitForSeconds(timer);
            listBrocolos.ForEach(item => item.SetActive(false));
            int randomNumber = randomNumberGenerator.Next(0, listBrocolos.Count);
            listBrocolos[randomNumber].SetActive(true);
        }
    }
}
