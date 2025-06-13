using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; 


public class HitScript : MonoBehaviour
{
    [SerializeField]
    private int boraco;
    
    [SerializeField]
    private AudioSource Prato1;
    
    [SerializeField]
    private AudioSource Prato2;
    
    [SerializeField]
    private AudioSource Prato3;
    
    [SerializeField]
    private AudioSource Chomp1;
    
    [SerializeField]
    private AudioSource Chomp2;
    
    [SerializeField]
    private AudioSource Chomp3;
    
    [SerializeField]
    private AudioSource Whoopie;
    
    [SerializeField]
    private AudioSource WhooHoo;
    
    [SerializeField]
    private AudioSource BatatasLaugh;
    
    [SerializeField]
    private AudioSource HamburgerLaugh;

    private System.Random randomNumberGenerator;

    void Start()
    {
        randomNumberGenerator = new System.Random();
    }
    
    public void HeadshotBrocollo()
    {
        GameManager.Acertou(boraco);
        int Som = randomNumberGenerator.Next(0, 3);
        switch(Som)
        {
            case 0:
                Chomp1.Play();
                break;

            case 1:
                Chomp2.Play();
                break;

            case 2:
                Chomp3.Play();
                break;
        }
        Whoopie.Play();
    }
    
    public void HeadshotCenoura()
    {
        GameManager.Acertou(boraco);
        int Som = randomNumberGenerator.Next(0, 3);
        switch(Som)
        {
            case 0:
                Chomp1.Play();
                break;

            case 1:
                Chomp2.Play();
                break;

            case 2:
                Chomp3.Play();
                break;
        }
        WhooHoo.Play();
    }

    public void WompWompBatatas()
    {
        GameManager.Errou(boraco);
        int Som = randomNumberGenerator.Next(0, 3);
        switch(Som)
        {
            case 0:
                Chomp1.Play();
                break;

            case 1:
                Chomp2.Play();
                break;

            case 2:
                Chomp3.Play();
                break;
        }
        BatatasLaugh.Play();
    }

    public void WompWompHamburger()
    {
        GameManager.Errou(boraco);
        int Som = randomNumberGenerator.Next(0, 3);
        switch(Som)
        {
            case 0:
                Chomp1.Play();
                break;

            case 1:
                Chomp2.Play();
                break;

            case 2:
                Chomp3.Play();
                break;
        }
        HamburgerLaugh.Play();
    }

    public void Prato()
    {
        int Som = randomNumberGenerator.Next(0, 3);
        switch(Som)
        {
            case 0:
                Prato1.Play();
                break;

            case 1:
                Prato2.Play();
                break;

            case 2:
                Prato3.Play();
                break;
        }
    }
}