using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthLight : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D healthLight;
    public float pulseSpeed;
    private float timer;
    private float healthRatio;

    // Start is called before the first frame update
    void Start()
    {
        healthLight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        healthRatio = GameMaster.HealthRatio();

        if(healthRatio <= 0.33f && healthRatio > 0f){
            pulseSpeed = healthRatio;

            timer += Time.deltaTime;
            if(timer > pulseSpeed){
                timer = 0;
                healthLight.enabled = !healthLight.enabled;
            }
        }
    }
}
