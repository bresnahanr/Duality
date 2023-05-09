using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ThirdPersonMovement : MonoBehaviour
{

    [SerializeField] private CharacterController controller;
    [SerializeField] private PlayerAttributes attributes;
    [HideInInspector] public float turnSmoothTime = 0.1f;
    [HideInInspector] public float turnSmoothVelocity;
    public Transform cam;

    // Update is called once per frame
    void Update()
    {
        if (GameVariables.isGooseMode)
            return;

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 inputNorm = new Vector3(horizontalInput, 0f, verticalInput).normalized;

		if (inputNorm.magnitude > 0.1f)
		{
			float targetAngle = getTargetAngle(inputNorm) + cam.eulerAngles.y;
			float angle = getRotatingAngle(targetAngle);

			transform.rotation = Quaternion.Euler(0f, angle, 0f);

			Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

			controller.Move(moveDir * Time.deltaTime * attributes.movementSpeed);
		}

	}

    private float getTargetAngle(Vector3 direction)
	{
        return Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
    }

    private float getRotatingAngle(float targetAngle)
	{
        return Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
    }
}
