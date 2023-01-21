using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;
    [SerializeField] bool showLabel = false;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();
    }

    void Update()
    {

        if (!Application.isPlaying)
        {
            label.enabled = true;
            DisplayCoordinates();
            UpdateObjectName();
        } else {
            label.enabled = showLabel;
        }

        SetLabelColor();
        ToggleLabels();
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            showLabel = !label.IsActive();
            label.enabled = showLabel;
        }
    }

    void SetLabelColor()
    {
        label.color = waypoint.IsPlaceable ? defaultColor : blockedColor;
    }

    void DisplayCoordinates()
    {
        #if (UNITY_EDITOR) 
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = coordinates.x + "," + coordinates.y;
        #endif
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
