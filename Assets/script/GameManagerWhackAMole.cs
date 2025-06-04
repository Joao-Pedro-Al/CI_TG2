using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static int score = 0;

    //0 = Fácil, 1 = Médio, 2 = Difícil
    public static int dificuldade = 0;

    public static int boracoAtengido = 0;

    public static int Atingido = 0;

    public static void SetDificuldade(int x){
        dificuldade = x;
    }


    public static void Acertou(int boraco)
    {
        score++;
        boracoAtengido = boraco;
        Atingido = 1;
    }

    public static void Errou(int boraco)
    {
        if (dificuldade == 2){
            score = score - 2;
        }
        else{
            score--;
        }
        boracoAtengido = boraco;
        Atingido = 1;
    }

    public static void setDesativar(int boraco)
    {
        boracoAtengido = boraco;
    }

    public static int Desativar()
    {
        if(Atingido == 0)
        {
            return -1;
        }
        else
        {
            Atingido = 0;
            return boracoAtengido;
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
