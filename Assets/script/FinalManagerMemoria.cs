using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinalManagerMemoria : MonoBehaviour
{
 [SerializeField]
 private TMP_Text answersText;
 public void Start()
 {
 answersText.text = GameManagerMemoria.GetSeconds().ToString();
 }
 public void TestAgain()
 {
 GameManager.Reset();
 SceneManager.LoadScene("MainScene");
 }
}
