using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private LayerMask objects;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;
    private Interactable interact;

    // Update is called once per frame
    void Update()
    {
        if (interact != null)
        {
            if (agent.remainingDistance <= interact.InteractRadius)
            {
                agent.SetDestination(gameObject.transform.position);
                interact.Interact();
                RemoveInteract();
            }
        }

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            animator.SetBool("Move", false);
        }
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                agent.SetDestination(hit.point);
                animator.SetBool("Move", true);

                SetInteract(hit.collider.GetComponent<Interactable>());
            }
        }
    }

    void SetInteract(Interactable interactable)
    {
        interact = interactable;
    }

    void RemoveInteract()
    {
        interact = null;
    }
}
