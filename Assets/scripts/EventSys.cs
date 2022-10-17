using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class GameData;

public class Result 
{
    public int totalMoney;
    public int income;
    public int employeeNum;

    void Apply(ref GameData data)
    {
    }
}

public class Option 
{
    string name;
    string description;
    
    Result result;
}

public class Event {
    int ID;
    string name;
    string description;
    int type;

    bool hasOption;
    List<Option> options;

    bool hasResult;
    Result eventResult;
}


public class EventSys : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
