using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingEnemy : MonoBehaviour
{
    public Sprite[] animSprites;
    int spriteIndex;
    SpriteRenderer animRenderer;
    float timeSinceSpriteChange;

    // Start is called before the first frame update
    void Start()
    {
        animRenderer = GetComponent<Renderer>() as SpriteRenderer;
        spriteIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpriteChange += Time.deltaTime;
        if(spriteIndex == animSprites.Length){
            Destroy(this.gameObject);
        }
        else if(timeSinceSpriteChange >= 0.1f){
            timeSinceSpriteChange = 0f;
            animRenderer.sprite = animSprites[spriteIndex];
            spriteIndex++;
        }
    }
}