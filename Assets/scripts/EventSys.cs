using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

enum EventType
{
    Normal = 1,
    Special = 2
}


[Serializable]
public class Result 
{
    public int totalMoney;
    public int income;
    public int employeeNum;
    public int fireRisk;

    public void Apply()
    {
        GameData.Instance.totalmoney += totalMoney;
        GameData.Instance.income += income;
        GameData.Instance.employee_num += employeeNum;
        GameData.Instance.firerisk += fireRisk;

        if (GameData.Instance.firerisk < 0)
        {
            GameData.Instance.firerisk = 0;
        }
        GameData.Instance.Render();
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

    public static EventPool Instance
    {
        get 
        {
            if (instance == null)
            {
                instance = new EventPool();
                instance.events = new List<Event>(); // list<> have to be initialized first!
            }
            return instance;
        }
    }

    public List<Event> events;

    public void LoadEventFormJSON(string path)
    {
        string json = File.ReadAllText(path);

        Event e = JsonUtility.FromJson<Event>(json);
        if (e != null)
        {
            // e.printJson();
            events.Add(e);
            // Debug.Log(e.options[0].name);
        }
        else
        {
            Debug.Log("json parse failed: " + path);
        }
    }

    public void Shuffle()
    {
        System.Random random = new System.Random();
        int n = events.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            Event value = events[k];
            events[k] = events[n];
            events[n] = value;
        }
    }

    public Event GetRandomEvent()
    {
        System.Random random = new System.Random();
        int idx = random.Next(events.Count);
        return events[idx];
    }

    public Event GetEvent(string name)
    {
        foreach (var e in events)
        {
            if (e.name == name)
            {
                return e;
            }
        }
        return null;
    }

    public Event GetEventContainWord(string word)
    {
        foreach (var e in events)
        {
            if (e.name.Contains(word))
            {
                return e;
            }
        }
        return null;
    }

}

// TODO: 
// 内部的Queue应该是改成优先队列
// 要搞一个Wrapper类，包含 Event 和 Month
// 这样可以添加时间信息到队列中, 实现几个月后触发事件的功能
// 也许这样需求Event增加一个字段，表示触发时间
public class EventQ
{
    // 老子真的不想写单例了
    // 但是不写成单例的话 按钮那里又咋整
    private static EventQ instance;

    private EventQ() { }

    public static EventQ Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new EventQ();
                instance.normalEvents = new Queue<Event>();
                instance.specialEvents = new Queue<Event>();
            }
            return instance;
        }
    }

    private Queue<Event> normalEvents;
    private Queue<Event> specialEvents;

    public void AddEvent(Event e)
    {
        if (e.type == (int)EventType.Normal)
        {
            normalEvents.Enqueue(e);
        }
        else if (e.type == (int)EventType.Special)
        {
            specialEvents.Enqueue(e);
        }
    }

    public Event GetEvent()
    {
        if (specialEvents.Count > 0)
        {
            return specialEvents.Dequeue();
        }
        else if (normalEvents.Count > 0)
        {
            return normalEvents.Dequeue();
        }
        else
        {
            return null;
        }
    }

    public bool IsEmpty()
    {
        return normalEvents.Count == 0 && specialEvents.Count == 0;
    }

}


public class EventSys : MonoBehaviour
{
    string path = @"Assets/Events/";

    void Awake()
    {
        EventPool eventPool = EventPool.Instance;
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
