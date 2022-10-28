using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insmoney : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject insuffmoney;

    public void End()
    {
        insuffmoney.SetActive(false);
    }
}
