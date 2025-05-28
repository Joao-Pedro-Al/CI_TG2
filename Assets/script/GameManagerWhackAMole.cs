using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static int score = 0;

    //0 = Fácil, 1 = Médio, 2 = Difícil
    public static int dificuldade = 0;


    public static void Acertou()
    {
        score++;
    }

    public static void Errou()
    {
        if (dificuldade == 2){
            score = score - 2;
        }
        else{
            score--;
        }
    }

    public static int Resultado()
    {
        return score;
    }

    public static int DifiAtual(){
        return dificuldade;
    }

    public static void Reset()
    {
        score = 0;
    }
}
