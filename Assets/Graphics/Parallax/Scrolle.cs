using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolle : MonoBehaviour
{

    public Transform[] backgrounds;
    public float[] objectScales;
    public float smoothSpeed = 1f;

    private Transform cam;
    public Vector3 previousCamPosition;


    private void Awake()
    {
        cam = Camera.main.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        previousCamPosition = cam.position;

        objectScales = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
        {
            objectScales[i] = backgrounds[i].position.z * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (previousCamPosition.x - cam.position.x) * objectScales[i];

            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothSpeed * Time.deltaTime);
        }
        previousCamPosition = cam.position;
    }

}
