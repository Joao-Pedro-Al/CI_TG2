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
    private List<GameObject> listCenouras;

    [SerializeField]
    private List<GameObject> listBatatas;

    [SerializeField]
    private List<GameObject> listHamburgers;

    [SerializeField]
    private TMP_Text timerText;

    private float currentTimer;

    private int randomNumberVegetais;

    private int randomNumberFritos;

    private System.Random randomNumberGenerator;

    void Start()
    {
        randomNumberGenerator = new System.Random();
        currentTimer = 0;
        StartCoroutine(ChangeVegetal());
        StartCoroutine(ChangeFrito());
        //print(difi);
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
            listCenouras.ForEach(item => item.SetActive(false));
            //int randomNumber = randomNumberGenerator.Next(0, listBrocolos.Count);

            do
            {
                randomNumberVegetais = randomNumberGenerator.Next(0, listBrocolos.Count);
            }
            while(randomNumberVegetais == randomNumberFritos);

            int BrocoloOuCenoura = randomNumberGenerator.Next(0, 2);

            //print(BrocoloOuCenoura);

            if(BrocoloOuCenoura == 0)
            {
                listBrocolos[randomNumberVegetais].SetActive(true);
            }
            else
            {
                listCenouras[randomNumberVegetais].SetActive(true);
            }
        }
    }

    IEnumerator ChangeFrito()
    {
        while (currentTimer < matchTimer)
        {
            yield return new WaitForSeconds(timer);
            listBatatas.ForEach(item => item.SetActive(false));
            listHamburgers.ForEach(item => item.SetActive(false));

            do
            {
                randomNumberFritos = randomNumberGenerator.Next(0, listBrocolos.Count);
            }
            while(randomNumberVegetais == randomNumberFritos);

            int BatatasOuHamburger = randomNumberGenerator.Next(0, 2);

            //print(BrocoloOuCenoura);

            if(BatatasOuHamburger == 0)
            {
                listBatatas[randomNumberFritos].SetActive(true);
            }
            else
            {
                listHamburgers[randomNumberFritos].SetActive(true);
            }
        }
    }
}
