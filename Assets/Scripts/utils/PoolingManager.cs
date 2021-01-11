using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    private static PoolingManager instance;
    public static PoolingManager Instance { 
        get { 
            return instance; 
        } 
    }

    public GameObject impactEffect;
    public int impactAmount = 5;

    private List<GameObject> impacts;

    void Awake() {
        instance = this;
        impacts = new List<GameObject>(impactAmount);

        for (int i = 0; i < impactAmount; i++) {
            GameObject effectInstance = Instantiate(impactEffect);
            effectInstance.transform.SetParent(transform);
            effectInstance.SetActive(false);

            impacts.Add(effectInstance);
        }
    }
    
    public GameObject GetImpact() {
        foreach (GameObject impact in impacts) {
            if (!impact.activeInHierarchy) {
                impact.SetActive(true);
                return impact;
            }
        }

        GameObject effectInstance = Instantiate(impactEffect);
        effectInstance.transform.SetParent(transform);
        impacts.Add(effectInstance);

        return effectInstance;
    }
}
