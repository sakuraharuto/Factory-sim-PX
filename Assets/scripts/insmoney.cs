using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class insmoney : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject insuffmoney;

    public void End()
    {
        insuffmoney.SetActive(false);
    }
}
