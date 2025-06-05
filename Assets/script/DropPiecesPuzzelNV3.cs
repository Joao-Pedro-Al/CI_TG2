using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DropPiecesPuzzelNV3 : MonoBehaviour, IDropHandler
{
    [SerializeField]
private AudioSource correctSound;
[SerializeField]
private AudioSource wrongSound;
 public void OnDrop(PointerEventData eventData)
 {
 if (eventData.pointerDrag == null) return;
 var collisionElement = eventData.pointerDrag.GetComponent<PuzzlePiecePuzzel>();
 if (collisionElement == null) return;

 if (collisionElement.targetImage.name == this.gameObject.name)
 {
 var currentColor = this.GetComponent<Image>().color;
 currentColor.a = 1;
 GetComponent<Image>().color = currentColor;
 Destroy(collisionElement.gameObject, 0);
 GameManagerPuzzelNV3.IncrementRightAnswer();
 correctSound.Play();
 }
 else
 {
 collisionElement.ResetImage();
 GameManagerPuzzelNV3.IncrementWrongAnswer();
 wrongSound.Play();
 }
 }
}