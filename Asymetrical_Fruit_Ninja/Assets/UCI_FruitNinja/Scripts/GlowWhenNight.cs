using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowWhenNight : MonoBehaviour
{
    public ChangeSkyBoxOvertime sky; 
    public Material glowingPart;
    public Color glowColor;
    // Start is called before the first frame update
    void Start()
    {
        glowColor = glowColor * Mathf.LinearToGammaSpace(24f);
        glowingPart.SetColor("_EmissionColor", Color.black);
    }


    public IEnumerator startGlowing()
    {
        float t = 0f;
        while(t <= 1f)
        {
            glowingPart.SetColor("_EmissionColor", Color.Lerp(Color.black, glowColor, t));
            t += Time.deltaTime;
            yield return null;
        }

    }

    public IEnumerator stopGlowing()
    {
        float t = 0f;
        while (t <= 1f)
        {
           
            glowingPart.SetColor("_EmissionColor", Color.Lerp(glowColor, new Color(0, 0, 0, 0), t));
            t += Time.deltaTime;
            yield return null;
        }
        ///yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        //glowingPart.SetColor("_EmissionColor", Color.Lerp(Color.black, glowColor,.1f));
    }
}
