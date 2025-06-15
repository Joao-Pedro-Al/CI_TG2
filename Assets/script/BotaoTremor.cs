using UnityEngine;
using System.Collections;

public class BotaoTremor : MonoBehaviour
{
    public float duracao = 0.2f;
    public float intensidade = 10f;

    private Vector3 posicaoOriginal;

    void Awake()
    {
        posicaoOriginal = transform.localPosition;
    }

    public void Tremer()
    {
        StopAllCoroutines();
        StartCoroutine(TremorCorrotina());
    }

    private IEnumerator TremorCorrotina()
    {
        float tempo = 0f;

        while (tempo < duracao)
        {
            float offsetX = Random.Range(-1f, 1f) * intensidade;
            float offsetY = Random.Range(-1f, 1f) * intensidade;

            transform.localPosition = posicaoOriginal + new Vector3(offsetX, offsetY, 0f);

            tempo += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = posicaoOriginal;
    }
}
