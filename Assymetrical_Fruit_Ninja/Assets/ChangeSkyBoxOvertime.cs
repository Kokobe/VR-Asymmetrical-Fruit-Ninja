using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkyBoxOvertime : MonoBehaviour
{
    public Material sky;
    // Start is called before the first frame update
    void Start()
    {
       // DynamicGI.UpdateEnvironment();

        StartCoroutine(updateLightning());
    }

    public Color sundownTop = new Color(236f / 255, 223f / 255, 148f / 255);
    public Color sundownBottom = new Color(224f / 255, 106f / 255, 92f / 255);

    public Color nightTop = new Color();
    public Color nightBottom = new Color();
    // Update is called once per frame
    float t = 0f;

    IEnumerator updateLightning()
    {
        while (t < 1f)
        {
            DynamicGI.UpdateEnvironment();
            yield return new WaitForSeconds(.25f);


        }

    }
    public bool Sundown = true;
    public bool Night = false;
    bool changingSundownToNight = true;
    bool changingNightToSundown = false;

    void Update()
    {

        if (Sundown && changingSundownToNight)
        {
            sky.SetColor("_Color2", Color.Lerp(sundownTop, nightTop, t)); //top
            sky.SetColor("_Color1", Color.Lerp(sundownBottom, nightBottom, t));
            //sky.SetFloat("Intensity", 100f);

            t += Time.deltaTime * .05f;

        }
        else if (Night && changingNightToSundown)
        {
            sky.SetColor("_Color2", Color.Lerp(nightTop, sundownTop, t)); //top
            sky.SetColor("_Color1", Color.Lerp(nightBottom, sundownBottom, t));
            //sky.SetFloat("Intensity", 100f);

            t += Time.deltaTime * .05f;
        }


        if (t > 1)
        {
            t = 0;
            StartCoroutine(updateLightning());

            if (changingSundownToNight) //end of sundown-night transition
            {
                //add in a delay ienumerator
                Night = true;
                Sundown = false;
                changingSundownToNight = false;
                changingNightToSundown = true;

                foreach (GlowWhenNight g in FindObjectsOfType<GlowWhenNight>()){

                    StartCoroutine(g.startGlowing());
                }
            }
            else if(changingNightToSundown) //end of night-sundown transition
            {
                Night = false;
                Sundown = true;
                changingSundownToNight = true;
                changingNightToSundown = false;

                foreach (GlowWhenNight g in FindObjectsOfType<GlowWhenNight>())
                {
                    StartCoroutine(g.stopGlowing());
                }
            }

        }



    }
}
