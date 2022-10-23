using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameData 
{
    public static GameData instance;
    
    private GameData() 
    {
        factoryStatus = GameObject.Find("FactoryStatus");
        Ttotalmoney = factoryStatus.transform.Find("Asset").GetComponent<TextMeshProUGUI>();
        Tequipment = factoryStatus.transform.Find("Equipment").GetComponent<TextMeshProUGUI>();
        Tfirerisk = factoryStatus.transform.Find("FireRisk").GetComponent<TextMeshProUGUI>();
        Temployees = factoryStatus.transform.Find("Employees").GetComponent<TextMeshProUGUI>();
        Tincome = factoryStatus.transform.Find("MonthlyIncome").GetComponent<TextMeshProUGUI>();
    
        init();
    }
    
    public static GameData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameData();
            }
            return instance;
        }
    }

    public GameObject factoryStatus;
    private TextMeshProUGUI Ttotalmoney;
    private TextMeshProUGUI Tequipment;
    private TextMeshProUGUI Tfirerisk;
    private TextMeshProUGUI Temployees;
    private TextMeshProUGUI Tincome;

    public void init()
    {
        totalmoney = 100;
        income = 0;
        employee_num = 0;
        firerisk = 0;
        equipment_quantity = 1;
        equipment_cost = 50;
        month_num = 1;
    }

    public int totalmoney;
    public int income;
    public int employee_num;
    public int firerisk;
    public int equipment_quantity;
    public int equipment_cost;
    public int month_num;

    public void Render()
    {
        Ttotalmoney.text = totalmoney.ToString();
        Tequipment.text = equipment_quantity.ToString();
        Tfirerisk.text = firerisk.ToString();
        Temployees.text = employee_num.ToString();
        Tincome.text = income.ToString();
    }

    public void EndTurn()
    {
        month_num += 1;
        totalmoney += income;
        firerisk += 1;
        Render();
    }
}


public class GameSystem : MonoBehaviour
{

    void Start()
    {
        GameData.Instance.Render();
        NewMonth();
    }

    public void AddEquipment()
    {
        // GameData.equipment_quantity++; 
        // GameData.totalmoney = GameData.totalmoney - GameData.equipment_cost;
    }
 
    public void NewMonth()
    {
        if (GameData.Instance.month_num > 2) 
        {
            Event e = EventPool.Instance.GetRandomEvent();
            EventRenderer.Instance.Render(e);
        }

        // if(GameData.firerisk>80)
        // {
        //      var x=EventPool.Instance.events[GameData.event_idx];
        // }
    }

    public void EndMonth()
    {
        GameData.Instance.EndTurn();
        Debug.Log("EndMonth: " + GameData.Instance.month_num);
        NewMonth();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
