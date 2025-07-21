using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WheelJoint2D))]
[RequireComponent(typeof(LineRenderer))]

public class Graund : MonoBehaviour
{
    [SerializeField] private Transform _pointGraund;
    [SerializeField] private LayerMask _layerMask;

    private RaycastHit2D _hit2D;
    private Vector3 _mouseGraund;
    private Camera _cameraGraynd;
    private WheelJoint2D _joint2D;
    private LineRenderer _lineRenderer;
    private bool _work = false;

    private void Start()
    {
        _cameraGraynd = Camera.main;
        _joint2D = GetComponent<WheelJoint2D>();
        _lineRenderer = GetComponent<LineRenderer>();
        _joint2D.enabled = false;
        _lineRenderer.positionCount = 0;
    }

    public void OFFGrayndLine()
    {
        _work = false;

        _joint2D.enabled = false;
        _lineRenderer.positionCount = 0;
    }

    public void ONGrayndLine()
    {
        _work = true;
        _hit2D = Physics2D.Raycast(_cameraGraynd.transform.position, _pointGraund.position, Mathf.Infinity, _layerMask);

        if (_work == true)
        {
            _joint2D.enabled = true;
            _joint2D.connectedAnchor = _hit2D.point;
            _lineRenderer.positionCount = 2;
        }

        DrawLineGraund();
    }

    private void DrawLineGraund()
    {
        if(_lineRenderer.positionCount > 0)
        {
            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, _pointGraund.position);
        }
    }
}
