using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


[Serializable]
public class Result 
{
    public int totalMoney;
    public int income;
    public int employeeNum;
    public int fireRisk;

    void Apply()
    {
        GameData.totalmoney += totalMoney;
        GameData.income += income;
        GameData.employeenum += employeeNum;
        GameData.firerisk += fireRisk;
    }
}

[Serializable]
public class Option 
{
    public string name;
    public string description;

    public Result result;
}


// unity 的 json 库是纯纯的垃圾
// { get; set; } 会导致序列化失败
// 不用 public 也会导致序列化失败
[Serializable]
public class Event {

    public int id;
    public string name;
    public string description;
    public int type;

    public bool hasResult;
    public Result result;

    public bool hasOption;
    public int optionNum;
    public List<Option> options;

    // for debugging
    public void printJson()
    {
        string json = JsonUtility.ToJson(this);
        Debug.Log(json);
    }
}


public class EventPool
{
    private static EventPool instance;

    private EventPool() { }

    public static EventPool GetInstance()
    {
        if (instance == null)
        {
            instance = new EventPool();
            instance.events = new List<Event>(); // list<> have to be initialized first!
        }
        return instance;
    }

    public List<Event> events;

    public void LoadEventFormJSON(string path)
    {
        string json = File.ReadAllText(path);

        Event e = JsonUtility.FromJson<Event>(json);
        if (e != null){
            // e.printJson();
            events.Add(e);
        }
        else
        {
            Debug.Log("json parse failed: " + path);
        }
    }
}

public class EventSys : MonoBehaviour
{
    string path = @"Assets/Events/";

    // Start is called before the first frame update
    void Start()
    {
        EventPool eventPool = EventPool.GetInstance();
        var eventsFiles = new DirectoryInfo(path).GetFiles("e*.json");

        foreach (var file in eventsFiles)
        {
            // Debug.Log(file.FullName);
            eventPool.LoadEventFormJSON(file.FullName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
