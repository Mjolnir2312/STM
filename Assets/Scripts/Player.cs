using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] CharacterController characterController;
    [SerializeField] private float speed;
    [SerializeField] private float turnSmoothTime;

    float turnSmoothVelocity;
    private static readonly int Run = Animator.StringToHash("Run");

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        //var movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            animator.SetBool(Run, true);
            characterController.Move(direction * speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool(Run, false);
        }
        
        //if (Vector3.SqrMagnitude(movement) > 0.1f)
        //{
        //    Debug.Log(Vector3.SqrMagnitude(movement));
        //    transform.rotation = Quaternion.LookRotation(movement);
        //    animator.SetBool(Run, true);
        //    characterController.SimpleMove(movement * speed);
        //}
        //else
        //{
        //    animator.SetBool(Run, false);
        //}
    }
}
