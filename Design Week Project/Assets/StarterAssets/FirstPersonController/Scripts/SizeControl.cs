using Cinemachine;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SizeControl : MonoBehaviour
{
    public CinemachineVirtualCamera _cameraControl;
    private StarterAssetsInputs _input;
    private FirstPersonController _controller;
    private CharacterController _controllerActual;

    public float maxFOV = 90f;
    public float minFOV = 40f;
    public float nominalScale = 1f;
    public float minimalScale = 0.2f;
    public float jumpHeightScaleModifier = 1f;
    public float slopeLimitScaleModifier = 2f;

    private float FOVScaleFactor;
    private float FOVScaleOffset;
    private float currentScale;
    private float nominalSpeed;
    private float nominalJumpHeight;
    private float nominalSlopeLimit;
    private float nominalStepOffset;
    private float nominalRadius;
    private float nominalHeight;
    private Vector3 nominalCenter;
    // Start is called before the first frame update
    private void Awake()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _controller = GetComponent<FirstPersonController>();
        _controllerActual = GetComponent<CharacterController>();
    }

    void Start()
    {
        currentScale = nominalScale;
        FOVScaleFactor = (maxFOV - minFOV) / (minimalScale - nominalScale);
        FOVScaleOffset = (maxFOV * nominalScale - minFOV * minimalScale) / (nominalScale - minimalScale);
        nominalSpeed = _controller.MoveSpeed;
        nominalJumpHeight = _controller.JumpHeight;
        nominalSlopeLimit = _controllerActual.slopeLimit;
        nominalStepOffset = _controllerActual.stepOffset;
        nominalRadius = _controllerActual.radius;
        nominalHeight = _controllerActual.height;
        nominalCenter = _controllerActual.center;
    }

    // Update is called once per frame
    void Update()
    {
        _input.scale = Mathf.Clamp(_input.scale,0.2f,1f);
        if (currentScale != _input.scale)
        {
            currentScale = Mathf.Lerp(currentScale, _input.scale, 5f * Time.deltaTime);
            transform.localScale = Vector3.one * currentScale;
            _cameraControl.m_Lens.FieldOfView = FOVScaleOffset + currentScale * FOVScaleFactor;
            _controller.MoveSpeed = nominalSpeed * currentScale;
            _controller.JumpHeight = nominalJumpHeight * currentScale * jumpHeightScaleModifier;
            _controllerActual.slopeLimit = nominalSlopeLimit * currentScale * slopeLimitScaleModifier;
            _controllerActual.stepOffset = nominalStepOffset * currentScale;
            _controllerActual.radius = nominalRadius * currentScale;
            _controllerActual.height = nominalHeight * currentScale;
            _controllerActual.center = nominalCenter * currentScale;
        }

    }
}
