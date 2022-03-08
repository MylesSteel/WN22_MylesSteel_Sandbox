using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
    public GameObject myObject;
    public MeshRenderer meshColor;
    public Slider red, green, blue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Setcolor()
    {
        Color color = meshColor.material.color;
        color.r = red.value;
        color.g = green.value;
        color.b = blue.value;
        meshColor.material.color = color;
       
    }

}
