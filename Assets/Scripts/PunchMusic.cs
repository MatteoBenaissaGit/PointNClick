using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PunchMusic : MonoBehaviour
{
    void Start()
    {
        MoveUp();
    }

    private void MoveUp()
    {
        transform.DOPunchScale(Vector3.one * 0.02f, 0.5f).OnComplete(MoveUp);
    }
}
