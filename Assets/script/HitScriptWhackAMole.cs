using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; 


public class HitScript : MonoBehaviour
{
    /*[SerializeField]
    private AudioSource AHH;*/
    
    public void Headshot()
    {
        GameManager.Acertou();
        //TODO:: Sons ou comer AHH.Play();
    }

    public void WompWomp()
    {
        GameManager.Errou();
    }
}