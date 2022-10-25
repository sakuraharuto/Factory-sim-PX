using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class EventRenderer
{
    private static EventRenderer instance;

    private EventRenderer() 
    { 
        init(); 
    }

    public static EventRenderer Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new EventRenderer();
            }
            return instance;
        }
    }

    public GameObject eventWin;
    [SerializeField]
    public TextMeshProUGUI eventInfo;
    public Button eventButton;

    public GameObject optionWin;
    public GameObject optionPrefab;

    private void init() 
    {
        eventWin = GameObject.Find("EventWin");
        eventInfo = GameObject.Find("EventInfo").GetComponent<TextMeshProUGUI>();
        eventButton = GameObject.Find("EventButton").GetComponent<Button>();
        eventButton.onClick.RemoveAllListeners();
        // eventButton.onClick.AddListener(() => { EventSys.Instance.NextEvent(); }); // TODO

        optionWin = GameObject.Find("OptionWin");
        optionPrefab = Resources.Load<GameObject>("Prefabs/Option");
        optionWin.SetActive(false);
    }
    
    public void Render(Event e)
    {
        eventInfo.text = "[" + e.name + "]: " + e.description;

        if (e.hasOption)
        {
            optionWin.SetActive(true);
            for (int i = 0; i < e.optionNum; i++)
            {
                GameObject option = Object.Instantiate(optionPrefab, optionWin.transform);
                option.transform.SetParent(optionWin.transform);
                var pos = option.transform.localPosition;
                pos.y -= i * 130 + 15; // 每一个选项往下移动 145 // TODO: 不要硬编码
                option.transform.localPosition = pos;
                option.GetComponentInChildren<TextMeshProUGUI>().text = "[" + e.options[i].name + "]: " + e.options[i].description;
                var btn = option.transform.Find("OptionButton").GetComponent<Button>();
                
                int idx = i; // 必须这样做 否则 listener 会捕获到最后一个 i
                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(() => {
                    Debug.Log("apply " + e.options[idx].name);
                    e.options[idx].result.Apply();
                    optionWin.SetActive(false);
                    Clear();
                });
            }
        }
    }

    public void Clear()
    {
        eventInfo.text = "Nothing Wrong";
        eventButton.onClick.RemoveAllListeners();
        optionWin.SetActive(false);
        foreach (Transform child in optionWin.transform)
        {
            Object.Destroy(child.gameObject);
        }
    }

}

public class EventsWin : MonoBehaviour
{
    void Awake()
    {
        
    }
}
