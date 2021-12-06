using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class Croak : MonoBehaviour
{
    public AudioClip croakClip;

    private BackgroundMusic theAM;

    // Start is called before the first frame update
    void Start()
    {
        theAM = FindObjectOfType<BackgroundMusic>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (croakClip != null)
                theAM.ChangeBGM(croakClip);
            return;
        }

    }
}
