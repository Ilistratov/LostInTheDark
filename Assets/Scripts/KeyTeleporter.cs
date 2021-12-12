using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTeleporter : MonoBehaviour
{
    bool needToTeleport = false;
    bool needToCheckPosition = false;
    
    LightInteractor lightInteractor;
    
    public float teleportRadius = 20F;
    public float lightLevelToTeleport = 0.01F;
    public List<Transform> teleportDestinations;
    float prvLightLevel = 0F;

    void Teleport()
	{
        if (teleportDestinations.Count > 0)
		{
            Random.InitState(System.DateTime.Now.Millisecond);
            int destinationInd = Random.Range(0, teleportDestinations.Count);
            GetComponent<Transform>().position = teleportDestinations[destinationInd].position;
            needToCheckPosition = true;
		}
        needToTeleport = false;
    }

    void Start()
    {
        lightInteractor = GetComponent<LightInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (needToCheckPosition)
		{
            needToTeleport = lightInteractor.lightLevel >= lightLevelToTeleport;
            needToCheckPosition = false;
		}
        else
		{
            needToTeleport = lightInteractor.lightLevel < lightLevelToTeleport && prvLightLevel >= lightLevelToTeleport;
		}
        prvLightLevel = lightInteractor.lightLevel;
        if (needToTeleport)
		{
            Teleport();
		}
    }
}
