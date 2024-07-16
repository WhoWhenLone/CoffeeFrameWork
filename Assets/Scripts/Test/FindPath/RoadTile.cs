using System;using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoadType
{
    [InspectorName("空地")]
    Empty = 0,
    [InspectorName("阻挡")]
    Obstacle = 1,
    [InspectorName("路径点")]
    PathPoint = 2,
    [InspectorName("起点")]
    Start = 3,
    [InspectorName("终点")]
    End = 4,
}

[ExecuteAlways]
public class RoadTile : MonoBehaviour
{
    private Color[] _roadColor = new[]
    {
        Color.gray, 
        Color.red, 
        Color.green, 
        Color.black, 
        Color.yellow, 
    };
    
    private RoadType _roadType;

    [SerializeField]
    public RoadType RoadType
    {
        get => _roadType;
        
        set
        {
            _roadType = value;
            ChangeColor();
        }
    }
    
    private void ChangeColor()
    {
        // var tempMaterial = new Material(this.gameObject.GetComponent<Renderer>().sharedMaterial);
        // tempMaterial.color = _roadColor[(int)_roadType];
        // this.gameObject.GetComponent<Renderer>().sharedMaterial = tempMaterial;
        
        this.gameObject.GetComponent<Renderer>().material.color = _roadColor[(int)_roadType];
    }

    public void RefreshColor()
    {
        this.gameObject.GetComponent<Renderer>().material.color = _roadColor[(int)_roadType];
    }
}
