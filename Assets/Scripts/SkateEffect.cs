using UnityEngine;

public class SkateEffect : MonoBehaviour
{
    [SerializeField] ParticleSystem particleSystemSkate;

    void Start()
    {
        particleSystemSkate.Stop();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            particleSystemSkate.Play();
        }
    }
}
