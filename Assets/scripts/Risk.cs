using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Risk : MonoBehaviour
{

    public float risk=10f;

    //Risk_img=GameObject.Find("Risk Level").GetComponent<Image>();

    private Image Risk_image;

     void Awake()
    {
        Risk_image = GameObject.Find("Risk Level").GetComponent<Image>();
    }


    //Risk_image=GameObject.Find("Risk Level").GetComponent<Image>();


    // Start is called before the first frame update
   
}
