using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    // Start is called before the first frame update
    public float minFlickInterval, maxFlickInterval;
    public float minLightIntensity;
    public float minFlickDuration, maxFlickDuration;

    private Light lightComponent;
    private float intervalTime, originalLightIntensity;
    private float flickDuration;

    void Start()
    {
        lightComponent = GetComponent<Light>();
        originalLightIntensity = lightComponent.intensity;
        intervalTime = Random.Range(minFlickInterval, maxFlickInterval);

    }

    // Update is called once per frame
    void Update()
    {
        Flick();
    }
    void Flick()
    {
        //si se acabo el intervalo de tiempo se comiensa el parapdeo
        if (intervalTime <= 0)
        {
            //duracion al parpadeo
            lightComponent.intensity = Random.Range(minLightIntensity, originalLightIntensity);
            intervalTime =Random.Range(minFlickInterval, maxFlickInterval);
            flickDuration = Random.Range(minFlickDuration, maxFlickDuration);
        }
        else
        {
            if(flickDuration > 0)
            {
                flickDuration -= 1f * Time.deltaTime;
            }
            else
            {
                intervalTime -= 1f * Time.deltaTime;
                lightComponent.intensity = originalLightIntensity;
            }
        }
    }
}
