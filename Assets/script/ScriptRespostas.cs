using UnityEngine;
using TMPro;

public class RespostaController : MonoBehaviour
{
    public TMP_Text textoCertas;
    public TMP_Text textoErradas;

    private int respostasCertas = 0;
    private int respostasErradas = 0;

    public void RespostaCerta()
    {
        respostasCertas++;
        AtualizarTexto();
    }

    // Agora recebe qual botão errado foi clicado
    public void RespostaErrada(BotaoTremor botaoQueTreme)
    {
        respostasErradas++;
        AtualizarTexto();

        // Só o botão clicado treme
        botaoQueTreme.Tremer();
    }

    private void AtualizarTexto()
    {
        textoCertas.text = respostasCertas.ToString();
        textoErradas.text = respostasErradas.ToString();
    }
}
