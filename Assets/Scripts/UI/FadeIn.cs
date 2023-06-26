using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public float fadeDuration;

    private CanvasGroup fadeCanvasGroup;
    private float currentAlpha = 1f;
    private float fadeSpeed;

    private void Start()
    {
        fadeCanvasGroup = GetComponent<CanvasGroup>();
        //fadeImage.enabled = true;
        fadeSpeed = 1f / fadeDuration;
    }

    private void Update()
    {
        // Reduce the alpha value based on time
        currentAlpha -= fadeSpeed * Time.deltaTime;

        // Update the image's color with the new alpha value
        fadeCanvasGroup.alpha = currentAlpha;

        // Disable the script and hide the fade image when the fade-in is complete
        if (currentAlpha <= 0f)
        {
            fadeCanvasGroup.gameObject.SetActive(false);
            enabled = false;
        }
    }
}
