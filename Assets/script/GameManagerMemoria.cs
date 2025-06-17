using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerMemoria : MonoBehaviour
{
    private static string formattedTime;

    // Salva o tempo formatado (ex: "02:15")
    public static void SetFormattedTime(string time)
    {
        formattedTime = time;
    }

    // Recupera o tempo formatado
    public static string GetFormattedTime()
    {
        return formattedTime;
    }

    // Reseta o tempo salvo
    public static void Reset()
    {
        formattedTime = "00:00";
    }
}
