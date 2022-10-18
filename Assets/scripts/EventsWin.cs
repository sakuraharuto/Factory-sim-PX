using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventsWin : MonoBehaviour
{
    GameObject eventsWin;
    Button eventBtn0, eventBtn1, eventBtn2;

    GameObject optionsWin;
    GameObject option0, option1, option2, option3, option4;
    Button option0Btn, option1Btn, option2Btn, option3Btn, option4Btn;


    [SerializeField]
    TextMeshProUGUI eventInfo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        eventsWin = GameObject.Find("EventsWin");
        eventBtn0 = GameObject.Find("EventButton0").GetComponent<Button>();
        eventBtn1 = GameObject.Find("EventButton1").GetComponent<Button>();
        eventBtn2 = GameObject.Find("EventButton2").GetComponent<Button>();

        optionsWin = GameObject.Find("OptionsWin");
        eventBtn0.onClick.RemoveAllListeners();
        eventBtn0.onClick.AddListener(() => { Debug.Log("Do"); optionsWin.SetActive(true); optionsWin.SetActive(true); });
        eventBtn1.onClick.RemoveAllListeners();
        eventBtn1.onClick.AddListener(() => { Debug.Log("later"); });
        eventBtn2.onClick.RemoveAllListeners();
        eventBtn2.onClick.AddListener(() => { Debug.Log("ignore");  eventInfo.text = "";});

        option0 = GameObject.Find("Option0");
        option1 = GameObject.Find("Option1");
        option2 = GameObject.Find("Option2");
        option3 = GameObject.Find("Option3");
        option4 = GameObject.Find("Option4");

        option0Btn = GameObject.Find("OptionButton0").GetComponent<Button>();
        option1Btn = GameObject.Find("OptionButton1").GetComponent<Button>();
        option2Btn = GameObject.Find("OptionButton2").GetComponent<Button>();
        option3Btn = GameObject.Find("OptionButton3").GetComponent<Button>();
        option4Btn = GameObject.Find("OptionButton4").GetComponent<Button>();

        option0Btn.onClick.RemoveAllListeners();
        option0Btn.onClick.AddListener(() => { Debug.Log("option0"); optionsWin.SetActive(false);});
        option1Btn.onClick.RemoveAllListeners();
        option1Btn.onClick.AddListener(() => { Debug.Log("option1"); optionsWin.SetActive(false);});
        option2Btn.onClick.RemoveAllListeners();
        option2Btn.onClick.AddListener(() => { Debug.Log("option2"); optionsWin.SetActive(false);});
        option3Btn.onClick.RemoveAllListeners();
        option3Btn.onClick.AddListener(() => { Debug.Log("option3"); optionsWin.SetActive(false);});
        option4Btn.onClick.RemoveAllListeners();
        option4Btn.onClick.AddListener(() => { Debug.Log("option4"); optionsWin.SetActive(false);});

        optionsWin.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
