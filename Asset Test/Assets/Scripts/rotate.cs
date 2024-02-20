using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    [SerializeField] float _spinSpeed;
    Vector3 _spinRate = Vector3.up;
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        _spinRate *= _spinSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_spinRate);
    }
}
