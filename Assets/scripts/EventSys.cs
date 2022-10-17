using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

[Serializable]
public class Result 
{
    public int totalMoney;
    public int income;
    public int employeeNum;

    void Apply()
    {
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

    // public Event(ref Event e)
    // {
    //     id = e.id;
    //     name = e.name;
    //     description = e.description;
    //     type = e.type;

    //     hasResult = e.hasResult;
    //     result = e.result;

    //     hasOptions = e.hasOptions;
    //     optionNum = e.optionNum;
    //     for (int i = 0; i < optionNum; i++)
    //     {
    //         // options[i] = e.options[i];
    //     }
    // }

    public int id;
    public string name;
    public string description;
    public int type;

    public bool hasResult;
    public Result result;

    public bool hasOption;
    public int optionNum;
    public List<Option> options;

    // public void init()
    // {
    //     id = 999;
    //     name = "test";
    //     description = "testdes";
    //     type = 1;
    //     hasResult = true;
    //     result = new Result();
    //     result.totalMoney = 10;
    //     result.income = 100;
    //     result.employeeNum = 1000;
    //     hasOption = true;
    //     optionNum = 2;
    //     options = new List<Option>();
    //     Option opt = new Option();
    //     opt.name = "opt1";
    //     opt.description = "opt1des";
    //     opt.result = new Result();
    //     opt.result.totalMoney = 111;
    //     opt.result.income = 222;
    //     opt.result.employeeNum = 333;
    //     options.Add(opt);
    //     Option opt2 = new Option();
    //     opt2.name = "opt2";
    //     opt2.description = "opt2des";
    //     opt2.result = new Result();
    //     opt2.result.totalMoney = 444;
    //     opt2.result.income = 555;
    //     opt2.result.employeeNum = 666;
    //     options.Add(opt2);
    // }

    public void printJson()
    {
        string json = JsonUtility.ToJson(this);
        Debug.Log(json);
    }
}


public class EventPool
{
    private static EventPool instance;

    // public Event(ref Event e)
    // {
    //     id = e.id;
    //     name = e.name;
    //     description = e.description;
    //     type = e.type;

    //     hasResult = e.hasResult;
    //     result = e.result;

    //     hasOptions = e.hasOptions;
    //     optionNum = e.optionNum;
    //     for (int i = 0; i < optionNum; i++)
    //     {
    //         // options[i] = e.options[i];
    //     }
    // }

    public int id;
    public string name;
    public string description;
    public int type;

    public bool hasResult;
    public Result result;

    public bool hasOption;
    public int optionNum;
    public List<Option> options;

    // public void init()
    // {
    //     id = 999;
    //     name = "test";
    //     description = "testdes";
    //     type = 1;
    //     hasResult = true;
    //     result = new Result();
    //     result.totalMoney = 10;
    //     result.income = 100;
    //     result.employeeNum = 1000;
    //     hasOption = true;
    //     optionNum = 2;
    //     options = new List<Option>();
    //     Option opt = new Option();
    //     opt.name = "opt1";
    //     opt.description = "opt1des";
    //     opt.result = new Result();
    //     opt.result.totalMoney = 111;
    //     opt.result.income = 222;
    //     opt.result.employeeNum = 333;
    //     options.Add(opt);
    //     Option opt2 = new Option();
    //     opt2.name = "opt2";
    //     opt2.description = "opt2des";
    //     opt2.result = new Result();
    //     opt2.result.totalMoney = 444;
    //     opt2.result.income = 555;
    //     opt2.result.employeeNum = 666;
    //     options.Add(opt2);
    // }

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
            instance.events = new List<Event>(); // list<> have to be initialized!
        }
        return instance;
    }

    public List<Event> events;

    public void LoadEventFormJSON(string path)
    {
        string json = File.ReadAllText(path);

        Event e = JsonUtility.FromJson<Event>(json);
        if (e != null){
            e.printJson();
            events.Add(e);
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
            Debug.Log(file.FullName);
            eventPool.LoadEventFormJSON(file.FullName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
