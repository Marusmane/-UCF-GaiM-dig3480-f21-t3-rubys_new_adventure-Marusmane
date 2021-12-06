using UnityEngine;
using System.Collections;


public class NonPlayerCharacter : MonoBehaviour
{
    public AudioClip frogClip;
    public float displayTime = 4.0f;
    public GameObject dialogBox;
    float timerDisplay;
    public GameObject Collision;

    void Start()
    {
        dialogBox.SetActive(false);
        timerDisplay = -1.0f;
        frogClip = GetComponent<AudioClip>();

    }

    void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);
            }
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }


    }

    public void DisplayDialog()
    {
        timerDisplay = displayTime;
        dialogBox.SetActive(true);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            controller.PlaySound(frogClip);


            }
        }
    }

