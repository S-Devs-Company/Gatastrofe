using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static int volumen;
    [SerializeField] private AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        volumen = PlayerPrefs.GetInt("vol");
        audioSource.volume = volumen / 100;
    }

    private void LateUpdate()
    {
        volumen = PlayerPrefs.GetInt("vol");
        audioSource.volume = volumen / 100;
    }
}
