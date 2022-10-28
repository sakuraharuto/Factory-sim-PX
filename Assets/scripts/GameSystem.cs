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
        income = 200;
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

    public void AddEquipment()
    {
        equipment_quantity++;
        totalmoney -= 400;
        income += equipment_quantity * 40;
        Render();
    }


    public void Addemployee()
    {
    
        employee_num++;
        totalmoney -= 200;
        income += employee_num * 20;
        Render();
    }


}


public class GameSystem : MonoBehaviour
{
    public GameObject insmoney;
    void Start()
    {
        GameData.Instance.Render();
        NewMonth();
    }

    public void Insmoney()
    {
        insmoney.SetActive(true);
    }

    public void Addemployee()
    {
        if(GameData.instance.totalmoney>=200)
        {
            GameData.instance.Addemployee();
            Debug.Log("employee");
        }
        else
        {
            Insmoney();
            Debug.Log("money is not enough");
        }
       
        
    }

    public void AddEquipment()
    {
        if(GameData.instance.totalmoney>=400)
        {
            GameData.instance.AddEquipment();
           Debug.Log("equipment");
        }
        else
        {
            Insmoney();
            Debug.Log("money is not enough");
        }
      
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
        Debug.Log("totalmoney: " + GameData.Instance.totalmoney);
        NewMonth();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
