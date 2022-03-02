using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UI_Hub : MonoBehaviour
{


    public Text[] statsInfo;
    public GameObject cup;





    public GameObject shop;
    public GameObject shopShowBtn;

    

    public Text moneyText;
    

    

    public GameObject map;

    


    public void Start()
    {
        ShowShop();
        if(Player.instance.completedLevels>0)
        {
            cup.SetActive(true);
        }

        moneyText.text = $"{Player.instance.Money} монет";
        
        UpdateShop();


    }



    public void AddMoney()
    {
        Player.instance.Money += 5;
        moneyText.text = $"{Player.instance.Money} монет";
        


    }



    public void Upgrade(int index)
    {
        if (Player.instance.Money < Player.instance.stats[index].cost)
        {
            Debug.Log("не хватает золота");
            return;
        }

        Player.instance.stats[index].amount += 1;
        Player.instance.Money -= Player.instance.stats[index].cost;
        Player.instance.stats[index].level++;
        Player.instance.stats[index].cost = Mathf.CeilToInt(Player.instance.stats[index].cost * 1.3f);
        UpdateShop();
        
        moneyText.text = $"{Player.instance.Money} монет";

    }

    

    public void ShowMap()
    {
        map.SetActive(!map.activeSelf);
    }


    public void ShowShop()
    {
        shop.SetActive(!shop.activeSelf);
        shopShowBtn.SetActive(!shop.activeSelf);
    }

    private void UpdateShop()
    {
        for (int i = 0; i < statsInfo.Length; i++)
            statsInfo[i].text = $"{Player.instance.stats[i].amount} {Player.instance.stats[i].nameOfStat} Уровень {Player.instance.stats[i].level}\n+ 1 {Player.instance.stats[i].nameOfStat} Стоимость {Player.instance.stats[i].cost}";
    }





}
