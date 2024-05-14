using UnityEngine;
using TMPro;
using System.Collections;

public class DeathText : MonoBehaviour
{
    public float fadeDuration = 2f; // Duration of the fade in seconds
    private TextMeshProUGUI textMesh;
    private Color originalColor;
    private bool fading = false;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        originalColor = textMesh.color;
        textMesh.enabled = false; // Disable the text at the start
    }

    public void StartFade()
    {
        if (!fading)
        {
            textMesh.enabled = true; // Enable the text before starting the fade
            StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeOut()
    {
        fading = true;

        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = 1f - (timer / fadeDuration); // Calculate the alpha value
            Color newColor = originalColor;
            newColor.a = alpha; // Set the new alpha value
            textMesh.color = newColor;
            yield return null;
        }

        fading = false;
        textMesh.enabled = false; // Disable the text at the end
        textMesh.color = originalColor; // Reset the alpha
    }
}
