using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidObject : MonoBehaviour
{
    [SerializeField] private Graund _graund;

    public void ONGraund()
    {
        _graund.ONGrayndLine();
    }

    public void OFFGraund()
    {
        _graund.OFFGrayndLine();
    }
}
