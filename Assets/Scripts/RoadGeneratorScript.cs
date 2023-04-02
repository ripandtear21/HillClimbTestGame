using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class RoadGeneratorScript : MonoBehaviour
{
    [SerializeField] private SpriteShapeController road;
    [Range(3f, 100f)] public int roadLength;
    [Range(1f, 50f)] public int xMult, yMult;
    [Range(0f, 1f)] public float curveSmooth;
    [SerializeField] private float noiseStep = 0.5f;
    private float bottom = 10f;
    private Vector3 lastPos;

    private void OnValidate()
    {
        road.spline.Clear();
        for(int i = 0; i < roadLength; i++)
        {
            lastPos = transform.position + new Vector3(i * xMult, Mathf.PerlinNoise(0, i * noiseStep) * yMult);
            road.spline.InsertPointAt(i, lastPos);
            if (i != 0 && i != roadLength - 1)
            {
                road.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                road.spline.SetLeftTangent(i, Vector3.left * curveSmooth * xMult);
                road.spline.SetRightTangent(i, Vector3.right * curveSmooth * xMult);
            }
        }
        road.spline.InsertPointAt(roadLength, new Vector3(lastPos.x, transform.position.y - bottom));
        road.spline.InsertPointAt(roadLength + 1, new Vector3(transform.position.x, transform.position.y - bottom));
    }
}
