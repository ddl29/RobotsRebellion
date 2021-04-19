using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarLife : MonoBehaviour
{
   public Image barLife;
   public Vida vida;
   public int vidaMaxima;
    
    void Update()
    {
        barLife.fillAmount = (float)vida.VidaCont/vidaMaxima;
    }
}
