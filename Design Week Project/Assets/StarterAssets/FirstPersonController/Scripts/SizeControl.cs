using Cinemachine;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SizeControl : MonoBehaviour
{
    public float changeSpeed;
    public float maximumAllowedScale = 3;
    public PlayerSizeData nomSize;
    public PlayerSizeData TargetSize;
    public CinemachineVirtualCamera _cameraControl;

    private FirstPersonController _controller;
    private CharacterController _controllerActual;
    private float currentScale;

    // Start is called before the first frame update
    private void Awake()
    {
        _controller = GetComponent<FirstPersonController>();
        _controllerActual = GetComponent<CharacterController>();
    }

    void Start()
    {
        currentScale = nomSize.scale;

        _cameraControl.m_Lens.FieldOfView = nomSize.FOV;

        _controller.MoveSpeed = nomSize.speed;
        _controller.SprintSpeed = nomSize.sprintSpeed;
        _controller.JumpHeight = nomSize.jumpHeight;
        _controller.GroundedOffset = nomSize.groundedOffSet;
        _controller.GroundedRadius = nomSize.groundedRadius;

        _controllerActual.slopeLimit = nomSize.slopeLimit;
        _controllerActual.stepOffset = nomSize.stepOffset;


    }

    // Update is called once per frame
    void Update()
    {
        if (currentScale != TargetSize.scale)
        {
            ChangeSize();
        }
    }

    void ChangeSize()
    {

        currentScale = Mathf.Lerp(currentScale, TargetSize.scale, changeSpeed * Time.deltaTime);
        transform.localScale = Vector3.one  * currentScale;

        _cameraControl.m_Lens.FieldOfView = Mathf.Lerp(_cameraControl.m_Lens.FieldOfView, TargetSize.FOV, changeSpeed * Time.deltaTime);

        _controller.MoveSpeed = Mathf.Lerp(_controller.MoveSpeed, TargetSize.speed, changeSpeed * Time.deltaTime);
        _controller.SprintSpeed = Mathf.Lerp(_controller.SprintSpeed, TargetSize.sprintSpeed, changeSpeed * Time.deltaTime);
        _controller.JumpHeight = Mathf.Lerp(_controller.JumpHeight, TargetSize.jumpHeight, changeSpeed * Time.deltaTime);
        _controller.GroundedOffset = Mathf.Lerp(_controller.GroundedOffset, TargetSize.groundedOffSet, changeSpeed * Time.deltaTime);
        _controller.GroundedRadius = Mathf.Lerp(_controller.GroundedRadius, TargetSize.groundedRadius, changeSpeed * Time.deltaTime);

        _controllerActual.slopeLimit = Mathf.Lerp(_controllerActual.slopeLimit, TargetSize.slopeLimit, changeSpeed * Time.deltaTime);
        _controllerActual.stepOffset = Mathf.Lerp(_controllerActual.stepOffset, TargetSize.stepOffset, changeSpeed * Time.deltaTime);

    }

    public bool SetTargetSize(PlayerSizeData _targetSize)
    {
        if (_targetSize.scale <= maximumAllowedScale)
        {
            TargetSize = _targetSize;
            return true;
        }
        return false;
    }
}
