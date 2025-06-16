using UnityEngine;
using TMPro;

public class RespostaController : MonoBehaviour
{
    public TMP_Text textoCertas;
    public TMP_Text textoErradas;

    void Start()
    {
        AtualizarTexto();
    }

    public void RespostaCerta()
    {
        if (QuizGameManager.instance != null)
        {
            QuizGameManager.instance.AdicionarCerta();
            AtualizarTexto();
        }
    }

    public void RespostaErrada()
    {
        if (QuizGameManager.instance != null)
        {
            QuizGameManager.instance.AdicionarErrada();
            AtualizarTexto();
        }
    }

    public void AtualizarTexto()
    {
        if (QuizGameManager.instance != null)
        {
            textoCertas.text = QuizGameManager.instance.respostasCertas.ToString();
            textoErradas.text = QuizGameManager.instance.respostasErradas.ToString();
        }
    }
}

