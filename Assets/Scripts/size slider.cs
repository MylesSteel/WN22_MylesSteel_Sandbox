using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sizeslider : MonoBehaviour
{
    public Slider x, y, z;
    public Transform sizeComp;
    [SerializeField]
    GameObject _myObject; 

    // Start is called before the first frame update
    void Start()
    {
         sizeComp = _myObject.GetComponent<Transform>();
    }

    public void SizeSlider()
    {
        Vector3 changeSize = new Vector3(x.value, y.value, z.value);
        sizeComp.localScale = changeSize;
    }
}

