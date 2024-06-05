using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Teclado : MonoBehaviour

{
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;    
    public Button button5;
    public Button button6;
    public Button button7;
    public Button button8;
    public Button button9;
    public Button button10;

    public void GenerarTeclado(List<string> opciones)
    {
        List<Button> botones = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10 };
        for (int i = 0; i < botones.Count; i++)
        {
            botones[i].GetComponentInChildren<TextMeshProUGUI>().SetText(opciones[i]);
        }

    }
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
