using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class close : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject jieshuMenu;

    public void End()
    {
        jieshuMenu.SetActive(false);
    }
}
