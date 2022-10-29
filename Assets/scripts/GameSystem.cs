using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameData 
{
    private static GameData instance;
    
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
        employee_num = 1;
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
        if(GameData.Instance.totalmoney>=200)
        {
            GameData.Instance.Addemployee();
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
        if(GameData.Instance.totalmoney>=400)
        {
            GameData.Instance.AddEquipment();
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
        if (GameData.Instance.month_num < 3) 
        {
            return;
        }

        System.Random random = new System.Random();

        do
        {
            Event e = EventPool.Instance.GetRandomEvent();
            // 目前暂时不希望特殊事件被随机出来
            if (e.type == (int)EventType.Normal)
            {
                EventQ.Instance.AddEvent(e);
            }
        } while (GameData.Instance.month_num > random.Next(1, 72));

        
        if(GameData.Instance.firerisk > 20)
        {
            if (GameData.Instance.firerisk > random.Next(0, 100))
            {
                Event efire = EventPool.Instance.GetEvent("Electric fire");
                EventQ.Instance.AddEvent(efire);
            }
        }

        if (EventQ.Instance.IsEmpty() == false)
        {
            Event e = EventQ.Instance.GetEvent();
            if (e != null)  // 没有可能是空的吧... 也就随便一写
            {
                EventRenderer.Instance.Render(e);
            }
        }
    }

    public void EndMonth()
    {
        GameData.Instance.EndTurn();

        // TODO: Clear Event Panel

        NewMonth();
    }

}
