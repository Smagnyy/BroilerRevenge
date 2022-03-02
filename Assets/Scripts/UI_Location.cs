using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Location : MonoBehaviour
{
    public Text moneyText;
    
    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = $"{Player.instance.Money} монет";
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = $"{Player.instance.Money} монет";
    }
}
