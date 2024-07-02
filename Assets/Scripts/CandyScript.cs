using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyScript : MonoBehaviour
{
    //public AudioClip drop;
    //AudioSource failaudio;
    // Start is called before the first frame update
    void Start()
    {
        //failaudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player") 
        {
            GameManager.Instance.IncrementScore();
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Boundary")
        {
            GameManager.Instance.DecreaseLives();
            Destroy(gameObject);
            //if (!failaudio.enabled)
           // {
           //failaudio.enabled = true;
           // }

            // Play the audio clip
            //failaudio.PlayOneShot(drop, 1.0f);
        }
    }
}
