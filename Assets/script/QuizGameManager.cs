    using UnityEngine;

public class QuizGameManager : MonoBehaviour
{
    public static QuizGameManager instance;

    public int respostasCertas = 0;
    public int respostasErradas = 0;

   void Awake()
{
    // Remove pai para ser root
    if (transform.parent != null)
    {
        transform.SetParent(null);
    }

    if (instance == null)
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    else
    {
        Destroy(gameObject);
    }
}


    public void AdicionarCerta()
    {
        respostasCertas++;
    }

    public void AdicionarErrada()
    {
        respostasErradas++;
    }

    public void Resetar()
    {
        respostasCertas = 0;
        respostasErradas = 0;
    }
}
