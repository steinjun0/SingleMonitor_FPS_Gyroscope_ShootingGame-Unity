using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGyro : MonoBehaviour
{

    [SerializeField] private Quaternion baseRotation = new Quaternion(0, 0, 1, 0);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestGyro()
    {
        transform.localRotation = GyroManager.Instance.GetGyroRotation() * baseRotation;
    }

}
