using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    SpriteRenderer animRenderer;
    float duration = 0f;

    // Start is called before the first frame update
    void Start()
    {
        animRenderer = GetComponent<Renderer>() as SpriteRenderer;
        transform.position = new Vector3(transform.position.x, transform.position.y, -5);
    }

    // Update is called once per frame
    void Update()
    {
        duration += Time.deltaTime;
        if(duration >= 0.1f){
            Destroy(this.gameObject);
        }
    }
}
