using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollider : MonoBehaviour
{
    public List<GameObject> Platforms = new List<GameObject>();

    protected void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Platform")
        {
            Platforms.Add(other.gameObject);
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Platform")
        {
            Platforms.Remove(other.gameObject);
        }
    }
}
