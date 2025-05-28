using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    [SerializeField]
    private TMP_Text TotalScore;

    private void Update()
    {
        TotalScore.text = GameManager.Resultado().ToString();
    }
}
