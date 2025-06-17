using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class CardsManagerMemoria : MonoBehaviour
{
    [SerializeField] private AudioSource correctSound;
    [SerializeField] private AudioSource wrongSound;

    [SerializeField]
    private List<CardScriptMemoria> listOfCards;

    [SerializeField]
    private List<Color> colors;

    [SerializeField]
    private List<Sprite> sprites;

    [SerializeField]
    private bool shouldUseSprites;

    [SerializeField]
    private AudioSource victoryMusic;

    [SerializeField]
    private TimerScriptMemoria timerScript; // <- nome atualizado (camelCase)

    private CardScriptMemoria firstSelectedItem;
    private CardScriptMemoria secondSelectedItem;
    private int numberOfMatches = 0;
    private CanvasGroup canvasGroup;

    public void Start()
    {
        canvasGroup = GetComponentInParent<CanvasGroup>();

        if ((!shouldUseSprites && listOfCards.Count / 2 != colors.Count) || (shouldUseSprites && listOfCards.Count / 2 != sprites.Count))
        {
            throw new ApplicationException("A configuração do GameManager está errada.");
        }

        for (var i = 0; i < listOfCards.Count; i++)
        {
            if (shouldUseSprites)
            {
                listOfCards[i].SetBelowImage(sprites[i / 2]);
            }
            else
            {
                listOfCards[i].SetBelowColor(colors[i / 2]);
            }
        }

        Shuffle(listOfCards);
    }

    void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            (list[k], list[n]) = (list[n], list[k]);
        }

        for (int i = 0; i < listOfCards.Count; i++)
        {
            listOfCards[i].transform.SetSiblingIndex(i);
        }
    }

    public void OnCardClick()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
            return;

        if (firstSelectedItem && secondSelectedItem)
            return;

        var clickedItem = EventSystem.current.currentSelectedGameObject.GetComponentInParent<CardScriptMemoria>();

        if (clickedItem == null || clickedItem == firstSelectedItem)
            return;

        if (!firstSelectedItem)
        {
            firstSelectedItem = clickedItem;
            firstSelectedItem.DisableCover();
        }
        else
        {
            secondSelectedItem = clickedItem;
            secondSelectedItem.DisableCover();
            CompareChosenItems();
        }
    }

 private void CompareChosenItems()
{
    bool isMatch;

    if (!shouldUseSprites)
    {
        isMatch = firstSelectedItem.Below.color == secondSelectedItem.Below.color;
    }
    else
    {
        isMatch = firstSelectedItem.Below.sprite == secondSelectedItem.Below.sprite;
    }

    if (isMatch)
    {
        numberOfMatches++;
        correctSound?.Play(); 
    }
    else
    {
        wrongSound?.Play(); 
    }

    StartCoroutine(ResetAndCheckFinish(isMatch ? 0 : 2, !isMatch));
}

    IEnumerator ResetAndCheckFinish(int numberOfSecondsToWait, bool shouldReset)
    {
        canvasGroup.interactable = false;
        yield return new WaitForSeconds(numberOfSecondsToWait);

        if (shouldReset)
        {
            firstSelectedItem.EnableCover();
            secondSelectedItem.EnableCover();
        }

        firstSelectedItem = null;
        secondSelectedItem = null;
        canvasGroup.interactable = true;

        if (numberOfMatches == listOfCards.Count / 2)
        {
            StartCoroutine(LoadFinalSceneMemoria());
        }
    }

    IEnumerator LoadFinalSceneMemoria()
    {
        // Obtem o tempo total
        float rawTime = timerScript.GetTimerAndStop();

        // Formata como MM:SS
        int minutes = Mathf.FloorToInt(rawTime / 60f);
        int seconds = Mathf.FloorToInt(rawTime % 60f);
        string formattedTime = $"{minutes:00}:{seconds:00}";

        // Envia para o GameManagerMemoria
        GameManagerMemoria.SetFormattedTime(formattedTime);

        victoryMusic.Play();

        yield return new WaitForSeconds(victoryMusic.clip.length);

        SceneManager.LoadScene("FinalSceneMemoria");
    }
}
