using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
    public Texture2D smg;
    public Texture2D empty;
    public Texture2D minigun;
    public Texture2D assault;

    public RawImage imagePanel;

    void Start(){
        imagePanel = this.GetComponent<RawImage>();
        imagePanel.texture = empty;
    }

    public void UpdateImage(string weapon){
        if(weapon == "SMG"){
            imagePanel.texture = smg;
        } else if(weapon == "Minigun"){
            imagePanel.texture = minigun;
        } else if(weapon == "MachineGun"){
            imagePanel.texture = assault;
        } else {
            imagePanel.texture = empty;
        }
    }
}
