using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.SceneManagement;

public class FinalSceneManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text score;

    public void Start()
    {
        score.text = GameManager.Resultado().ToString();
    }

    public void TentarNovamente()
    {
        GameManager.Reset();
        SceneManager.LoadScene("InicioWhackAMole");
    }
}
