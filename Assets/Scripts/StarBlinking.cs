using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBlinking : MonoBehaviour
{
    public float fadingTime;
    public float fadingLimit;
    private Transform _transform;
    private float _time;
    void Start()
    {
        _transform = GetComponent<Transform>();
    }
    
    void Update()
    {
        if (gameObject.name != "Star")
        {
            _time += Time.deltaTime;
            if (_time >= fadingTime)
            {
                _time = 0;
                _transform.localScale -= Vector3.one* 0.01f;
                if (_transform.localScale.x < fadingLimit)
                {
                    Destroy(gameObject);
                }
            }
        }
        
    }
}
