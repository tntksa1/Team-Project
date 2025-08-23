using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeartIcon : MonoBehaviour
{
    public Image img;                          
    [Header("Colors")]
    public Color fullColor = Color.white;     
    public Color halfColor = new Color(1, 1, 1, 0.8f);
    public Color emptyColor = new Color(1, 1, 1, 0.35f); 

    public void SetState(float fraction)
    {
        fraction = Mathf.Clamp01(fraction);

        if (fraction >= 0.99f) img.color = fullColor;
        else if (fraction > 0f) img.color = halfColor;   
        else img.color = emptyColor;

        StopAllCoroutines();
        StartCoroutine(Pop());
    }

    IEnumerator Pop()
    {
        var rt = (RectTransform)transform;
        Vector3 a = Vector3.one, b = Vector3.one * 1.08f;
        float t = 0f;
        while (t < 0.12f) { t += Time.unscaledDeltaTime; rt.localScale = Vector3.Lerp(a, b, t / 0.12f); yield return null; }
        t = 0f;
        while (t < 0.12f) { t += Time.unscaledDeltaTime; rt.localScale = Vector3.Lerp(b, a, t / 0.12f); yield return null; }
        rt.localScale = Vector3.one;
    }
}
