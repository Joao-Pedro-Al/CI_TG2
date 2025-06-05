using System.Collections; 
using System.Collections.Generic; 
using TMPro; 
using UnityEngine; 
using UnityEngine.SceneManagement; 
public class FinalSceneManagerPuzzelNV2 : MonoBehaviour 
{ 
    [SerializeField] 
    private TMP_Text rightAnswersText; 
 
    [SerializeField] 
    private TMP_Text wrongAnswersText; 
 
    public void Start() 
    { 
        rightAnswersText.text = GameManagerPuzzelNV2.GetRightAnswer().ToString(); 
        wrongAnswersText.text = GameManagerPuzzelNV2.GetWrongAnswer().ToString(); 
    } 
 
    public void TestAgain() 
    { 
        GameManagerPuzzelNV2.Reset(); 
        SceneManager.LoadScene("menuNIveisPuzzel"); 
    } 
}

