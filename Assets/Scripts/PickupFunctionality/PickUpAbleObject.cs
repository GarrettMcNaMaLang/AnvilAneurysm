using System.Collections.Generic;
using UnityEngine;

public class PickUpAbleObject : MonoBehaviour
{
    [SerializeField]
    private List<Renderer> renderers;

    private List<Material> materials;

    [SerializeField]
    private Color color;

    void Awake()
    {
        materials = new List<Material>();
        foreach (var renderer in renderers)
        {
            materials.AddRange(new List<Material>(renderer.materials));
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BeingLookedAt(bool value)
    {
        if (value)
        {
            Debug.Log("Object is Seen");
            foreach (var material in materials)
            {
                material.EnableKeyword("_EMISSION");

                material.SetColor("_EmissionColor", color);
            }
        }
        else
        {
            foreach (var material in materials)
            {
                material.DisableKeyword("_EMISSION");

                
            }
        }
    }

    void Disappear()
    {
        DestroyImmediate(this);
    }
}
