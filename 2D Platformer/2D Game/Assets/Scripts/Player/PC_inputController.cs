using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterMovement))]
public class PC_inputController : MonoBehaviour
{
    CharacterMovement playerMovement; 

    float move;
    bool jump;
    bool crawling;

    private void Start()
    {
        playerMovement = GetComponent<CharacterMovement>();
    }

    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonUp("Jump"))
        {
            jump = true;
        }
        crawling = Input.GetKey(KeyCode.LeftControl);

        if (Input.GetKey(KeyCode.E))
        {
            playerMovement.StartCasting();
        }

        if(!IsPointerOverUI())
        if (Input.GetButtonUp("Fire1"))
        {
            playerMovement.StartStrike();
        }

    }

    private void FixedUpdate()
    {
        playerMovement.Move(move, jump, crawling);
        jump = false;
    }

    private bool IsPointerOverUI() => EventSystem.current.IsPointerOverGameObject();
}
