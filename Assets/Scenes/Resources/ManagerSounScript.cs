using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSounScript : MonoBehaviour
{
    public static AudioClip soundBullet, soundBullet2, soundBullet3,
                            explosionspawn,explosionpared, portalsound,
                            soundgruñido ;
    static AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
         //[Audio]
        soundBullet = Resources.Load<AudioClip>("Bullet1");
        soundBullet2 = Resources.Load<AudioClip>("Bullet2");
        explosionspawn = Resources.Load<AudioClip>("explosionSpawn");
        explosionpared = Resources.Load<AudioClip>("pared");
        portalsound = Resources.Load<AudioClip>("Portal");
        soundgruñido = Resources.Load<AudioClip>("grunido");
        
        audioSource = GetComponent<AudioSource>();
    }
     public static void playSounds(string clip){
        switch(clip){
            case "Bullet1":
            audioSource.PlayOneShot(soundBullet);
            break;
            case "Bullet2":
            audioSource.PlayOneShot(soundBullet2);
            break;
            case "explosionSpawn":
            audioSource.PlayOneShot(explosionspawn);
            break;
            case "pared":
            audioSource.PlayOneShot(explosionpared);
            break;
            case "Portal":
            audioSource.PlayOneShot(portalsound);
            break;
            case "grunido":
            audioSource.PlayOneShot(soundgruñido);
            break;
           
         
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
