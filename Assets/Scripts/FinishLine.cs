using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FinishLine : MonoBehaviour
{
    [SerializeField] ParticleSystem finishParticle = new();
    AudioSource finishAudio;
    float delayTime = 2f;

    void Start()
    {
        finishAudio = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SkateCollider")
        {
            Debug.Log("Finished");
            finishAudio.Play();
            finishParticle.Play();
            Invoke("ReloadScene", delayTime);
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}

