using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float healthRatio = GameMaster.HealthRatio();//(float)GameMaster.playerHealth / (float)GameMaster.startingHealth;
        //float linearHR = Mathf.Pow(healthRatio, 2.0f);

        healthBarImage.fillAmount = Mathf.Clamp(healthRatio, 0, 1f);

        if(healthRatio <= 0.33){
            healthBarImage.color = new Color32(255, 0, 0, 255);
        }
        else if(healthRatio <= 0.66){
            healthBarImage.color = new Color32(255, 255, 0, 255);
        }
        else{
            healthBarImage.color = new Color32(0, 255, 0, 255);
        }
    }
}
