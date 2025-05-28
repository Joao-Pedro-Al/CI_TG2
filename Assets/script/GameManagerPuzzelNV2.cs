using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.SceneManagement;
public static class GameManagerPuzzelNV2
{
 private static int _rightAnswers = 0;
 private static int _wrongAnswers = 0;
 public static void IncrementRightAnswer()
 {
 _rightAnswers++;
 if (_rightAnswers == 9)
 {
 SceneManager.LoadScene("FinalScenePuzzelNV2");
 }
 }
public static void IncrementWrongAnswer()
 {
 _wrongAnswers++;
 }
 public static int GetRightAnswer()
 {
 return _rightAnswers;
 }
 public static int GetWrongAnswer()
 {
 return _wrongAnswers;
 }
 public static void Reset()
 {
 _rightAnswers = 0;
 _wrongAnswers = 0;
 }
}
