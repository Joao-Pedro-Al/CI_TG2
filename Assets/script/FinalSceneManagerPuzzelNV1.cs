using System.Collections; 
using System.Collections.Generic; 
using TMPro; 
using UnityEngine; 
using UnityEngine.SceneManagement; 
public class FinalSceneManagerPuzzelNV1 : MonoBehaviour 
{ 
    [SerializeField] 
    private TMP_Text rightAnswersText; 
 
    [SerializeField] 
    private TMP_Text wrongAnswersText; 
 
    public void Start() 
    { 
        rightAnswersText.text = GameManagerPuzzelNV1.GetRightAnswer().ToString(); 
        wrongAnswersText.text = GameManagerPuzzelNV1.GetWrongAnswer().ToString(); 
    } 
 
    public void TestAgain() 
    { 
        GameManagerPuzzelNV1.Reset(); 
        SceneManager.LoadScene("menuNIveisPuzzel"); 
    } 
}
