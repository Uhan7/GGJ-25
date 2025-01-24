using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;

public class camera_shake : MonoBehaviour
{
    public CinemachineCamera currentCmVCam;

    [SerializeField] private bool shakeOnEnable;

    [SerializeField] private float shakeDuration;
    [SerializeField] private AnimationCurve strengthCurve;
    [SerializeField] private float strengthMultiplier;

    private void OnEnable()
    {
        if (shakeOnEnable) StartCoroutine(screenShake());
    }

    void Update()
    {

    }

    public IEnumerator screenShake()
    {
        currentCmVCam = FindFirstObjectByType<CinemachineCamera>();
        CinemachineBasicMultiChannelPerlin cmBmcp = currentCmVCam.GetComponent<CinemachineBasicMultiChannelPerlin>();
        float elapsedTime = 0f;

        while (elapsedTime <= shakeDuration)
        {
            elapsedTime += Time.deltaTime;
            cmBmcp.FrequencyGain = strengthCurve.Evaluate(elapsedTime / shakeDuration) * strengthMultiplier;
            cmBmcp.AmplitudeGain = strengthCurve.Evaluate(elapsedTime / shakeDuration) * strengthMultiplier * 2;
            yield return null;
        }
        cmBmcp.FrequencyGain = 0;
        cmBmcp.AmplitudeGain = 0;
    }
}
