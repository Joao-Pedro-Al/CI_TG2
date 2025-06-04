using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; 


public class HitScript : MonoBehaviour
{
    [SerializeField]
    private int boraco;
    
    /*[SerializeField]
    private AudioSource AHH;*/
    
    public void Headshot()
    {
        GameManager.Acertou(boraco);
        //TODO:: Sons ou comer AHH.Play();
    }

    public void WompWomp()
    {
        GameManager.Errou(boraco);
    }
}