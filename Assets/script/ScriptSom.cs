using UnityEngine;
using UnityEngine.UI;

public class ToggleMusic : MonoBehaviour
{
    public AudioSource MusicManager;  // Arraste aqui o GameObject com o AudioSource
    public Button Som;                // Arraste aqui o botão da UI

    private bool tocando = true;

    void Start()
    {
        // Verifica se as referências estão atribuídas no Inspector
        if (MusicManager != null && Som != null)
        {
            Som.onClick.AddListener(TrocarEstadoMusica);
        }
        else
        {
            Debug.LogError("Referência faltando: atribua o MusicManager e o Som no Inspector.");
        }
    }

    void TrocarEstadoMusica()
    {
        if (MusicManager.isPlaying)
        {
            MusicManager.Pause();
            tocando = false;
            Debug.Log("Música pausada");
        }
        else
        {
            MusicManager.Play();
            tocando = true;
            Debug.Log("Música tocando");
        }
    }
}
