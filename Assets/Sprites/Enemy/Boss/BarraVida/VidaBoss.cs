using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaBoss : MonoBehaviour
{
    public static int vidaBoss = 100;
    public Image barraVida;
    public GameObject explosion;  
    public GameObject portalFinal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        barraVida.fillAmount = (float)vidaBoss/100;
        if(VidaBoss.vidaBoss ==0){
            portalFinal.SetActive(true);
            Destroy(this.gameObject);
            //PONER SONIDO DE DESTRUCCION O VICTORIA
        }
    }

    void OnTriggerEnter2D(Collider2D c){
        if(c.CompareTag("Bala1") | c.CompareTag("Bala2")){
            vidaBoss--;
            Destroy(c.gameObject);
            GameObject effect = Instantiate(explosion,c.transform.position,Quaternion.identity);
            Destroy(effect,.5f);
        }
    }
}
