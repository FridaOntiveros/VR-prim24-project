using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShakeUI : MonoBehaviour
{
    private GameObject panel;

    public float duration = 2f, strength = 2f, randomness = 60f;
    public int vibrato = 6;
    public bool snapping = false, fadeOut = false;

    void Start()
    {
        panel = this.gameObject;
        Shake();
    }

    void Shake()
    {
        panel.transform.DOShakePosition(duration, strength, vibrato, randomness, snapping, fadeOut, ShakeRandomnessMode.Harmonic)
            .OnComplete(() => Shake());
    }


}
