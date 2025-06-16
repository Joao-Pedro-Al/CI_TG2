using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void MudarCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }

    public void MudarCenaComReset(string nomeCena)
    {
        if (QuizGameManager.instance != null)
            QuizGameManager.instance.Resetar();

        SceneManager.LoadScene(nomeCena);
    }
}
