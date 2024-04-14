using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullseye : MonoBehaviour
{
    public GameObject bullseye;

    // Start is called before the first frame update
    void Start()
    {
        //bullseye = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameMaster.pause){
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
            transform.position = mousePosition;
        }
    }
}
