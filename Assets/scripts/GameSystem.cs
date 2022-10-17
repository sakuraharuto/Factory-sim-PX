using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameData 
{

    public static int totalmoney;
    public static int income;
    public static int employeenum;
    public static int firerisk;
    public static int equipment_quantity;
    public static int equipment_cost;

   /* public GameData(int TotalMoney,  int EmployeeNum, int FireRisk, int Equipment_Quantity)
    {
        totalmoney = TotalMoney;
        employeenum = EmployeeNum;
        firerisk = FireRisk;
        equipment_quantity = Equipment_Quantity;
       
    }*/

   /* public void addEmployee()
    { 
        employeenum ++;
    }*/

  

    private int months;
}


public class GameSystem : MonoBehaviour
{
    // Start is called before the first frame update

    //NewMonth ???????????
    public TextMeshProUGUI Ttotalmoney;
    public TextMeshProUGUI Tequipment;
    public TextMeshProUGUI Tfirerisk;
    public TextMeshProUGUI Temployees;
    public TextMeshProUGUI Tincome;

    public  void  showe()
    {
        Ttotalmoney = transform.GetComponent<TextMeshProUGUI>();
        Tequipment = transform.GetComponent<TextMeshProUGUI>();
        Tfirerisk = transform.GetComponent<TextMeshProUGUI>();
        Temployees = transform.GetComponent<TextMeshProUGUI>();
        Tincome = transform.GetComponent<TextMeshProUGUI>();
        Ttotalmoney.text = GameData.totalmoney.ToString();
        Tequipment.text = GameData.equipment_quantity.ToString();
        Tfirerisk.text = GameData.firerisk.ToString();
        Temployees.text = GameData.employeenum.ToString();
        Tincome.text = GameData.income.ToString();
    }

    public int GetTotalMoney()
    {
        return GameData.totalmoney;
    }

    public void addEquipment()
    {
        GameData.equipment_quantity++; 
        GameData.totalmoney = GameData.totalmoney - GameData.equipment_cost;
    }

    public int GetIncome()
    {
        GameData.income = GameData.equipment_quantity * 200;
        return GameData.income;
    }

    public void SetFireRisk(int n)
    {
        GameData.firerisk = n;
    }


   
    void NewMonth()
    {
        if(GameData.firerisk>50)
        {
            
        }
    }

    //EndMonth ??????
    void EndMonth()
    {
        GameData.income = GetIncome();
        GameData.totalmoney = GameData.totalmoney + GameData.income;
    }

    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
