using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FinalManagerMemoria : MonoBehaviour
{
    [SerializeField]
    private TMP_Text answersText;

    private void Start()
    {
        // Mostra o tempo formatado na tela final
        answersText.text = $"Tempo: {GameManagerMemoria.GetFormattedTime()}";
    }

    public void TestAgain()
    {
        // Reseta o tempo salvo
        GameManagerMemoria.Reset();

        // Recarrega a cena principal
        SceneManager.LoadScene("JogoDaMemoriaJogar");
    }
}
