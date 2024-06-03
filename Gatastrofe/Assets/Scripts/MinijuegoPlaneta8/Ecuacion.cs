using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ecuacion : MonoBehaviour
{
    // Variables de la vista
    public TextMeshProUGUI num1;
    public TextMeshProUGUI num2;
    public TextMeshProUGUI operador;
    public TextMeshProUGUI res;

    // Variables internas
    private int numero1;
    private int numero2;
    private char operacion;
    private double resultado;
    private int incognita;

    public Ecuacion()
    {
        this.numero1 = 0;
        this.numero2 = 0;
        this.resultado = 0;
        this.incognita = 0;
    }

    // Getters de las variables internas
    public int GetNumero1() => numero1;
    public int GetNumero2() => numero2;
    public char GetOperacion() => operacion;
    public double GetResultado() => resultado;
    public int GetIncongnita() => incognita;
    public string GetValorIncongnita()
    {
        switch (incognita)
        {
            case 1:
                return Convert.ToString(numero1);
            case 2:
                return Convert.ToString(operacion);
            case 3:
                return Convert.ToString(numero2);
            case 4:
                return Convert.ToString(resultado);
            default:
                throw new ArgumentOutOfRangeException();

        }
    }

    // Función para generar la ecuación
    public void GenerarEcuacion()
    {
        System.Random rand = new System.Random();
        //define num1 y num2
        numero1 = rand.Next(1, 11);
        numero2 = rand.Next(1, 11);

        //define la operación y la realiza
        switch (rand.Next(1, 5))
        {
            case 1:
                operacion = '+';
                resultado = numero1 + numero2;
                break;
            case 2:
                operacion = '-';
                bool cambio = false;
                while (numero1 < numero2)
                {
                    if (cambio)
                    {
                        numero2 = rand.Next(1, 11);
                        cambio = !cambio;
                    }
                    else
                    {
                        numero1 = rand.Next(1, 11);
                        cambio = !cambio;
                    }
                }
                resultado = numero1 - numero2;
                break;
            case 3:
                operacion = '*';
                resultado = numero1 * numero2;
                break;
            case 4:
                operacion = '/';
                cambio = false;
                while (numero1 % numero2 != 0)
                {
                    if (cambio)
                    {
                        numero2 = rand.Next(1, 11);
                        cambio = !cambio;
                    }
                    else
                    {
                        numero1 = rand.Next(1, 11);
                        cambio = !cambio;
                    }
                }
                resultado = numero1 / numero2;
                break;
            default:
                Console.WriteLine("ayuda");
                break;
        }

        //Crea la incognita
        incognita = rand.Next(1, 5);
    }

    // Función para Resolver la ecuación con los valores en la vista
    public bool Resolver()
    {
        try
        {
            switch (incognita)
            {
                case 1:
                    switch (operacion)
                    {
                        case '+':
                            return int.Parse(num1.GetParsedText()) + numero2 == resultado;
                        case '-':
                            return int.Parse(num1.GetParsedText()) - numero2 == resultado;

                        case '*':
                            return int.Parse(num1.GetParsedText()) * numero2 == resultado;
                        case '/':
                            return int.Parse(num1.GetParsedText()) / numero2 == resultado;
                        default:
                            Console.WriteLine("WTF");
                            break;
                    }
                    break;
                case 2:
                    switch (operador.GetParsedText()[0])
                    {
                        case '+':
                            return (numero1 + numero2) == resultado;
                        case '-':
                            return (numero1 - numero2) == resultado;

                        case '*':
                            return (numero1 * numero2) == resultado;
                        case '/':
                            return (numero1 / numero2) == resultado;
                        default:
                            Console.WriteLine("WTF");
                            break;
                    }
                    break;
                case 3:
                    switch (operacion)
                    {
                        case '+':
                            return numero1 + int.Parse(num2.GetParsedText()) == resultado;
                        case '-':
                            return numero1 - int.Parse(num2.GetParsedText()) == resultado;
                        case '*':
                            return numero1 * int.Parse(num2.GetParsedText()) == resultado;
                        case '/':
                            return numero1 / int.Parse(num2.GetParsedText()) == resultado;
                        default:
                            Console.WriteLine("WTF");
                            break;
                    }
                    break;
                case 4:
                    return resultado == double.Parse(res.GetParsedText());
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return false;

        }
        catch (Exception)
        {
            return false;
        }
    }

    // Función para pintar la ecuación dependiendo de si se resolvió o no
    public void PintarEcuacion()
    {
        if (Resolver())
        {
            num1.GetComponentInParent<Image>().color = Color.green;
            num1.GetComponentInParent<Button>().interactable = false;
            num2.GetComponentInParent<Image>().color = Color.green;
            num2.GetComponentInParent<Button>().interactable = false;
            operador.GetComponentInParent<Image>().color = Color.green;
            operador.GetComponentInParent<Button>().interactable = false;
            res.GetComponentInParent<Image>().color = Color.green;
            res.GetComponentInParent<Button>().interactable = false;
        }
        else
        {
            num1.GetComponentInParent<Image>().color = Color.red;
            num2.GetComponentInParent<Image>().color = Color.red;
            operador.GetComponentInParent<Image>().color = Color.red;
            res.GetComponentInParent<Image>().color = Color.red;
        }
    }

    // Función para mostrar la ecuación en los elementos de la vista
    public void MostrarEcuacion()
    {
        switch (incognita)
        {
            case 1:
                num1.text = "?";
                num2.text = numero2.ToString();
                num2.GetComponentInParent<Button>().interactable = false;
                operador.text = operacion.ToString();
                operador.GetComponentInParent<Button>().interactable = false;
                res.text = resultado.ToString();
                res.GetComponentInParent<Button>().interactable = false;
                break;
            case 2:
                num1.text = numero1.ToString();
                num1.GetComponentInParent<Button>().interactable = false;
                num2.text = numero2.ToString();
                num2.GetComponentInParent<Button>().interactable = false;
                operador.text = "?";
                res.text = resultado.ToString();
                res.GetComponentInParent<Button>().interactable = false;
                break;
            case 3:
                num1.text = numero1.ToString();
                num1.GetComponentInParent<Button>().interactable = false;
                num2.text = "?";
                operador.text = operacion.ToString();
                operador.GetComponentInParent<Button>().interactable = false;
                res.text = resultado.ToString();
                res.GetComponentInParent<Button>().interactable = false;

                break;
            case 4:
                num1.text = numero1.ToString();
                num1.GetComponentInParent<Button>().interactable = false;
                num2.text = numero2.ToString();
                num2.GetComponentInParent<Button>().interactable = false;
                operador.text = operacion.ToString();
                operador.GetComponentInParent<Button>().interactable = false;
                res.text = "?";

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public override string ToString()
    {
        return "numero 1: " + this.GetNumero1() + "\n"
                + "numero 2: " + this.GetNumero2() + "\n"
                + "operacion: " + this.GetOperacion() + "\n"
                + "resultado: " + this.GetResultado() + "\n"
                + "incognita en el elemento: " + this.GetIncongnita();
    }
}
