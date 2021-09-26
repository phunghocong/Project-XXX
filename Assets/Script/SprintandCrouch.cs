using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintandCrouch : MonoBehaviour
{

    private PlayerMovement playermovement;

    public float sprint_Speed = 15f;

    public float move_Speed = 10f;

    public float crouch_speed = 2f;

    private Transform look_transform;

    private float stand_height = 0.9f;

    private float crouch_height = 0.05f;

    [SerializeField] private bool isCrouching;

    private PlayerAuido playerfootstep;

    private float sprint_volume = 1f;

    private float crouch_volumne = 0.1f;

    private float walk_volumne_min = 0.2f, walk_volumne_max = 0.6f;


    private float walk_stepdis = 0.4f;


    private float sprint_stepdis = 0.25f;

    private float crouch_stepdis = 0.5f;

    private void Awake()
    {
        playermovement = GetComponent<PlayerMovement>();

        look_transform = transform.GetChild(0);

        playerfootstep = GetComponentInChildren<PlayerAuido>();

        // Update is called once per frame
    }

    private void Start()
    {
        playerfootstep.volumne_min = walk_volumne_min;

        playerfootstep.volumne_max = walk_volumne_max;

        playerfootstep.stepdistance = walk_stepdis;

    }
    void Update()
    {
        Sprint();

        Crouching();
    }

    void Sprint()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && !isCrouching)
        {
            playermovement.speed = sprint_Speed;


            playerfootstep.stepdistance = sprint_stepdis;

            playerfootstep.volumne_min = sprint_volume;

            playerfootstep.volumne_max = sprint_volume; 
        }

        if(Input.GetKeyUp(KeyCode.LeftShift)&& !isCrouching)
        {
            playermovement.speed = move_Speed;

            playerfootstep.stepdistance = walk_stepdis;

            playerfootstep.volumne_min = walk_volumne_min;

            playerfootstep.volumne_max = walk_volumne_max;

            
        }
    }

   void Crouching()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {

            //nếu đang bò thì đứng lên
            if (isCrouching)
            {

                //vị trí hiện tại dwuaj vào player
                look_transform.localPosition = new Vector3(0f, stand_height, 0f);

                playermovement.speed = move_Speed;


                playerfootstep.stepdistance = walk_stepdis;

                playerfootstep.volumne_min = walk_volumne_min;

                playerfootstep.volumne_max = walk_volumne_max;


                isCrouching = false;

            }
            //ngược lại
            else
            {
                look_transform.localPosition = new Vector3(0f,crouch_height, 0f);

                playermovement.speed = crouch_speed;

                playerfootstep.stepdistance = crouch_stepdis;

                playerfootstep.volumne_max = crouch_volumne;

                playerfootstep.volumne_min = crouch_volumne;

                isCrouching = true;


            }
        }
    }
}
