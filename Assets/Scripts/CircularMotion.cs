using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMotion : MonoBehaviour
{
    public float speed = 5.0f;
    public float radius = 0.1f;
    public GameObject pedal;

    private Vector3 centre;
    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        centre = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        speed = Mathf.Abs(pedal.transform.position.y - 1.29f) * 10;
        angle += speed * Time.deltaTime;
        var offset = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0) * radius;
        transform.position = centre + offset;
    }
}
