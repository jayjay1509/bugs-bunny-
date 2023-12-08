using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cooldwon : MonoBehaviour
{
    private static cooldwon instance;
    public float cooldownTime = 2.0f;
    private float lastTeleportTime;

    public static cooldwon Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<cooldwon>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(cooldwon).Name;
                    instance = obj.AddComponent<cooldwon>();
                }
            }
            return instance;
        }
    }

    public bool CanTeleport()
    {
        return Time.time > lastTeleportTime + cooldownTime;
    }

    public void UpdateTeleportTime()
    {
        lastTeleportTime = Time.time;
    }
}
