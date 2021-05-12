using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bed : MonoBehaviour
{
    SpriteRenderer sprRenderer;
    public Sprite changedBed;

    public AudioClip impact;
    AudioSource audioSource;
    public bool isChanged;
    // Start is called before the first frame update
    void Start()
    {
        sprRenderer = this.GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        isChanged = false;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeBed(isChanged);
    }

    void ChangeBed(bool isChanged)
    {
        if (isChanged)
        {
            sprRenderer.sprite = changedBed;
            audioSource.PlayOneShot(impact, 0.7f);
        }
    }
}
