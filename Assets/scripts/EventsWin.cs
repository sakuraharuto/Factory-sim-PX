using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventsWin : MonoBehaviour
{

    Button btn0, btn1, btn2;

    GameObject optionsWin;
    Button optBtn0;

    [SerializeField]
    TextMeshProUGUI eventInfo;

    // Start is called before the first frame update
    void Start()
    {
        optionsWin = GameObject.Find("OptionsWin");
        optBtn0 = GameObject.Find("OptionsBtn0").GetComponent<Button>();
        optBtn0.onClick.AddListener(() => { optionsWin.SetActive(false); });
        optionsWin.SetActive(false);

        btn0 = GameObject.Find("Button0").GetComponent<Button>();
        // btn1 = GameObject.Find("Button1").GetComponent<Button>();
        btn2 = GameObject.Find("Button2").GetComponent<Button>();

        btn0.onClick.AddListener(() => { optionsWin.SetActive(true); });
        btn2.onClick.AddListener(() => { eventInfo.text = ""; });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
