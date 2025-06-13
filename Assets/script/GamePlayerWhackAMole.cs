using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GamePlayer : MonoBehaviour
{
    private int difi = GameManager.DifiAtual();

    //[Range(0, 2)]
    private int timer;

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

    private int randomNumberVegetais1;
    private int randomNumberVegetais2;

    private int randomNumberFritos1;
    private int randomNumberFritos2;

    private int boracoAtengido;

    private System.Random randomNumberGenerator;

    void Start()
    {

        randomNumberGenerator = new System.Random();
        currentTimer = 0;
        StartCoroutine(ChangeVegetal());
        StartCoroutine(ChangeFrito());
        //print(difi);

        switch(difi){
        case 0:
            timer = 2;
            break;

        case 1:
            timer = 1;
            break;

        case 2:
            timer = 1;
            break;
        }
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

        boracoAtengido = GameManager.Desativar();

        currentTimer += Time.deltaTime;

        float NumberOfSeconds = matchTimer - currentTimer;
        float seconds = Mathf.FloorToInt(NumberOfSeconds % 60);
        timerText.text = $"{seconds:00}";

        if(boracoAtengido != -1){
            ObjectHit();
        }
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
                randomNumberVegetais1 = randomNumberGenerator.Next(0, listBrocolos.Count);
                randomNumberVegetais2 = randomNumberGenerator.Next(0, listBrocolos.Count);
            }
            while(randomNumberVegetais1 == randomNumberFritos1 || randomNumberVegetais2 == randomNumberFritos1 || randomNumberVegetais1 == randomNumberFritos2 || randomNumberVegetais2 == randomNumberFritos2 || randomNumberVegetais1 == randomNumberVegetais2);

            int BrocoloOuCenoura1 = randomNumberGenerator.Next(0, 2);
            int BrocoloOuCenoura2 = randomNumberGenerator.Next(0, 2);

            //print(BrocoloOuCenoura);

            if(BrocoloOuCenoura1 == 0)
            {
                listBrocolos[randomNumberVegetais1].SetActive(true);
            }
            else
            {
                listCenouras[randomNumberVegetais1].SetActive(true);
            }

            if(difi == 0){
                if(BrocoloOuCenoura2 == 0)
                {
                    listBrocolos[randomNumberVegetais2].SetActive(true);
                }
                else
                {
                    listCenouras[randomNumberVegetais2].SetActive(true);
                }
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
                randomNumberFritos1 = randomNumberGenerator.Next(0, listBrocolos.Count);
                randomNumberFritos2 = randomNumberGenerator.Next(0, listBrocolos.Count);
            }
            while(randomNumberVegetais1 == randomNumberFritos1 || randomNumberVegetais2 == randomNumberFritos1 || randomNumberVegetais1 == randomNumberFritos2 || randomNumberVegetais2 == randomNumberFritos2 || randomNumberFritos1 == randomNumberFritos2);

            int BatatasOuHamburger1 = randomNumberGenerator.Next(0, 2);
            int BatatasOuHamburger2 = randomNumberGenerator.Next(0, 2);

            //print(BrocoloOuCenoura);

            if(BatatasOuHamburger1 == 0)
            {
                listBatatas[randomNumberFritos1].SetActive(true);
            }
            else
            {
                listHamburgers[randomNumberFritos1].SetActive(true);
            }

            if(difi == 2){
                if(BatatasOuHamburger2 == 0)
                {
                    listBatatas[randomNumberFritos2].SetActive(true);
                }
                else
                {
                    listHamburgers[randomNumberFritos2].SetActive(true);
                }
            }
        }
    }

    public void ObjectHit()
    {
        //int boraco = GameManager.Desativar();

        //print(boracoAtengido + " - GamePlayer");

        listBrocolos[boracoAtengido].SetActive(false);
        listCenouras[boracoAtengido].SetActive(false);
        listBatatas[boracoAtengido].SetActive(false);
        listHamburgers[boracoAtengido].SetActive(false);
    }
}
