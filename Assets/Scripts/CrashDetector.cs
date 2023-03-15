using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float ReloadDelay = 1f;

    [SerializeField] ParticleSystem deathEffect;
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ground")
        {
            deathEffect.Play();
            Invoke("ReloadScene", ReloadDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
