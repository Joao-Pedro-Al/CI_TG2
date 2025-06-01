using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.SceneManagement;

public class DificuldadeManagerWhackAMole : MonoBehaviour
{
    public void ComecarJogo(int difiselecionada)
    {
        GameManager.SetDificuldade(difiselecionada);
        SceneManager.LoadScene("GameSceneWhackAMole");
    }
}
