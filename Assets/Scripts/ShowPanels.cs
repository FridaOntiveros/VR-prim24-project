using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShowPanels : MonoBehaviour
{
    public RectTransform objetivosPanel, creditosPanel;
    public float animationDuration = 2f;
    public Vector3 originalPositionObj, originalPositionCred;
    public Vector2 targetPosition;

    private bool isObjetivosVisible = true, isCreditosVisible = true;

    private void Start()
    {
        // Asegúrate de que el panel esté en su posición inicial
        originalPositionObj = objetivosPanel.localPosition;
        originalPositionCred = creditosPanel.localPosition;
        // objetivosPanel.anchoredPosition = Vector2.zero;
        objetivosPanel.gameObject.SetActive(true);
        creditosPanel.gameObject.SetActive(false);
        MueveCreditos();
    }

    public void MueveObjetivos()
    {
        if (isObjetivosVisible)
        {
            // Animación de desplazamiento a la derecha y desaparición
            objetivosPanel.DOAnchorPos(targetPosition, animationDuration).OnComplete(() => objetivosPanel.DOScale(0.1f, animationDuration));
        }
        else
        {
            // Si el panel está invisible, lo hacemos visible y lo desplazamos a su posición original
            objetivosPanel.DOScale(1f, animationDuration);
            objetivosPanel.DOAnchorPos(originalPositionObj, animationDuration);
            //objetivosPanel.DOFade(1f, animationDuration);
        }

        // Cambiamos el estado del panel
        isObjetivosVisible = !isObjetivosVisible;
    }

    public void MueveCreditos()
    {
        if (isCreditosVisible)
        {
            // Animación de desplazamiento a la derecha y desaparición
            creditosPanel.DOAnchorPos(targetPosition, animationDuration).OnComplete(() => creditosPanel.DOScale(0.1f, animationDuration));
        }
        else
        {
            // Si el panel está invisible, lo hacemos visible y lo desplazamos a su posición original
            creditosPanel.gameObject.SetActive(true);
            creditosPanel.DOScale(1f, animationDuration);
            creditosPanel.DOAnchorPos(originalPositionCred, animationDuration);
        }

        // Cambiamos el estado del panel
        isCreditosVisible = !isCreditosVisible;
    }
}
