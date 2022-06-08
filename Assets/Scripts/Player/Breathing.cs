using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Breathing : MonoBehaviour
{
    [SerializeField]
    private Image oxygenImage;

    [SerializeField]
    private float oxygenMax = 1;

    [SerializeField]
    private float oxygenCurrent = 1;

    [SerializeField]
    private float oxygenTimeToFill = 5f; 

    // Assim vai subir suavemente
    [SerializeField]
    private float timeLimitCurrent = 0f;

    // Para parar de respirar quando entrar numa núvem
    private Coroutine currentBreathingCoroutine = null;

    private bool isBreathing = false;

    [SerializeField]
    private UnityEvent Die;

    private void Start () 
    {
        UpdateOxygenBar();

        StartBreathing();
    }


    private IEnumerator Breath () {
        while (oxygenCurrent <= oxygenMax) {
            oxygenCurrent += Time.deltaTime / oxygenTimeToFill;
            UpdateOxygenBar();
            yield return null;
        }

        // A execução só chega aqui depois de sair do while
        // Ou seja, no fim de encher a barra (chegar ao máximo)
        if (oxygenCurrent > oxygenMax) {
            oxygenCurrent = oxygenMax;
            UpdateOxygenBar();
            DismissBar();
        }

    }

    private void StartBreathing () {
        // Evitar duplicados
        StopBreathing();
        isBreathing = true;
        currentBreathingCoroutine = StartCoroutine(Breath());
    }

    private void StopBreathing () {
        if (currentBreathingCoroutine != null) {
            StopCoroutine(currentBreathingCoroutine);
        }
        isBreathing = false;
    }

    private void UpdateOxygenBar () {
        oxygenImage.fillAmount = oxygenCurrent; 
    }

    public void EnterToxicCloud (float timeLimit) {
        StopBreathing();

        // Pede à núvem qual é o seu tempo limite e ela devolve
        // Por exemplo, devolve 8 s
         timeLimitCurrent = timeLimit;
        // Para veres a barra a reagir de forma diferente, como se tivesses
        // em núvens diferentes, descomenta a linha abaixo e descomenta a de cima :)
        
        //timeLimitCurrent = Random.Range(1f, 10f);

        StartAsphyxiation(timeLimitCurrent);
    }

    public void ExitToxicCloud () {
        // Sai da nuvem, volta a conseguir respirar
        StartBreathing();
    }

    private IEnumerator Asphyxiate (float originalLimit) {

        // Lembrar que o oxygen atual vai de 0 a 1 como a barra da UI
        // Aqui dizemos: a núvem tem um limite original, como por exemplo 8
        // Mas, se o oxigénio atual for 0.4, em vez de estar cheio
        // No fim só conseguimos aguentar 8 * 0.4 = 3.2f segundos

        float limitConsideringCurrentOxygen = originalLimit * oxygenCurrent;
        
        // A partir do momento em que sai da nuvem, volta a respirar
        // Ou seja, o StartBreathing é chamado
        // Desta forma o isBreathing passa a true e pára o ciclo abaixo

        while (!isBreathing && oxygenCurrent > 0) {
            oxygenCurrent -= Time.deltaTime / limitConsideringCurrentOxygen;
            UpdateOxygenBar();
            yield return null;
        }

        if (oxygenCurrent < 0) {
            oxygenCurrent = 0;
        }

        if(oxygenCurrent == 0)
        {
            Die.Invoke();
        }

        UpdateOxygenBar();
    }

    private void StartAsphyxiation(float originalLimit) {
        StartCoroutine(Asphyxiate(originalLimit));
    }

    public void DisplayBar()
    {
        oxygenImage.gameObject.SetActive(true);
    }

    public void DismissBar()
    {
        oxygenImage.gameObject.SetActive(false);
    }

}
