using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class CardsManagerMemoria : MonoBehaviour
{
    [SerializeField]
    private List<CardScriptMemoria> listOfCards;

    [SerializeField]
    private List<Color> colors;

    [SerializeField]
    private List<Sprite> sprites; // TODO para o final da ficha

    [SerializeField]
    private bool shouldUseSprites; // TODO Alterar quando usar sprites

    [SerializeField]
    private AudioSource victoryMusic;

    [SerializeField]
    private TimerScriptMemoria timerScript;

    private CardScriptMemoria firstSelectedItem;
    private CardScriptMemoria secondSelectedItem;
    private int numberOfMatches = 0;
    private CanvasGroup canvasGroup;

    public void Start()
    {
        canvasGroup = GetComponentInParent<CanvasGroup>();

        int totalCards = listOfCards.Count;
        int totalPairs = totalCards / 2;

        if ((!shouldUseSprites && totalPairs != colors.Count) ||
            (shouldUseSprites && totalPairs != sprites.Count))
        {
            throw new ApplicationException("A configuração do GameManagerMemoria está errada.");
        }

        // Ativar todas as Covers
        foreach (var card in listOfCards)
        {
            card.EnableCover();
        }

        // Atribuir cores ou sprites (duplicar e baralhar)
        if (shouldUseSprites)
        {
            List<Sprite> duplicatedSprites = new List<Sprite>();
            foreach (var sprite in sprites)
            {
                duplicatedSprites.Add(sprite);
                duplicatedSprites.Add(sprite);
            }

            Shuffle(duplicatedSprites);

            for (int i = 0; i < listOfCards.Count; i++)
            {
                listOfCards[i].SetBelowImage(duplicatedSprites[i]);
            }
        }
        else
        {
            List<Color> duplicatedColors = new List<Color>();
            foreach (var color in colors)
            {
                duplicatedColors.Add(color);
                duplicatedColors.Add(color);
            }

            Shuffle(duplicatedColors);

            for (int i = 0; i < listOfCards.Count; i++)
            {
                listOfCards[i].SetBelowColor(duplicatedColors[i]);
            }
        }

        // Trocar visualmente a ordem dos cartões na hierarquia
        Shuffle(listOfCards);
        for (int i = 0; i < listOfCards.Count; i++)
        {
            listOfCards[i].transform.SetSiblingIndex(i);
        }
    }

    // Baralha uma lista
    void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            (list[k], list[n]) = (list[n], list[k]);
        }
    }

    public void OnCardClick()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            return;
        }

        if (firstSelectedItem && secondSelectedItem)
        {
            return;
        }

        var clickedItem = EventSystem.current.currentSelectedGameObject.GetComponentInParent<CardScriptMemoria>();

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
        if (!shouldUseSprites)
        {
            if (firstSelectedItem.Below.color == secondSelectedItem.Below.color)
            {
                numberOfMatches++;
                StartCoroutine(ResetAndCheckFinish(0, false));
            }
            else
            {
                StartCoroutine(ResetAndCheckFinish(2, true));
            }
        }
        else
        {
            // TODO: Comparar sprites
        }
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
            StartCoroutine(LoadFinalScene());
        }
    }

    IEnumerator LoadFinalScene()
    {
        GameManagerMemoria.SetSeconds(timerScript.GetTimerAndStop());

        victoryMusic.Play();
        yield return new WaitForSeconds(victoryMusic.clip.length);

        SceneManager.LoadScene("FinalScene");
    }
}
