using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAuido : MonoBehaviour
{
    [SerializeField] private AudioSource footstep_sound;

    [SerializeField] private AudioClip[] footstep_clip;

    private CharacterController controller;

    public float volumne_min, volumne_max;

    private float accumlated_distance;

    public float stepdistance;

    private void Awake()
    {
        footstep_sound = GetComponent<AudioSource>();

        controller = GetComponentInParent<CharacterController>();
    }


    private void Update()
    {
        ChecktoPlayFootstep();    
    }


    private void ChecktoPlayFootstep()
    {

        //accumlated_distance là đại lượng chúng ta có thể đi xa được bao nhiêu

        if (!controller.isGrounded)
        {
            return;
        }
        if(controller.velocity.sqrMagnitude > 0)
        {
            accumlated_distance += Time.deltaTime;  

            if(accumlated_distance > stepdistance)
            {
                footstep_sound.volume = Random.Range(volumne_min, volumne_max);

                footstep_sound.clip = footstep_clip[Random.Range(0, footstep_clip.Length)];

                footstep_sound.Play();

                accumlated_distance = 0f;
            }
        }
        else
        {
            accumlated_distance = 0f;
        }

    }
}
