using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayTime = 2f;
    [SerializeField] ParticleSystem particleSystemHead = new();

    AudioSource crashAudio;

    bool hasCrashed = false;

    void Start()
    {
        crashAudio = GetComponent<AudioSource>();
        particleSystemHead = GetComponent<ParticleSystem>();
        particleSystemHead.Stop();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashAudio.Play();
            particleSystemHead.Play();
            Invoke("ReloadScene", delayTime);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        particleSystemHead.Stop();
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
