using System.Collections; 
using System.Collections.Generic; 
using TMPro; 
using UnityEngine; 
using UnityEngine.SceneManagement; 
public class FinalSceneManagerPuzzelNV3 : MonoBehaviour 
{ 
    [SerializeField] 
    private TMP_Text rightAnswersText; 
 
    [SerializeField] 
    private TMP_Text wrongAnswersText; 
 
    public void Start() 
    { 
        rightAnswersText.text = GameManagerPuzzelNV3.GetRightAnswer().ToString(); 
        wrongAnswersText.text = GameManagerPuzzelNV3.GetWrongAnswer().ToString(); 
    } 
 
    public void TestAgain() 
    { 
        GameManagerPuzzelNV3.Reset(); 
        SceneManager.LoadScene("menuNIveisPuzzel"); 
    } 
}
