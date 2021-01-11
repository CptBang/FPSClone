using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
	#region Singleton
	static PoolingManager instance;
    public static PoolingManager Instance { 
        get { 
            return instance; 
        }
    }
    void Awake() {
        if (instance != null) {
            Destroy(this);
            return;
        }
        instance = this;
    }
    #endregion

	public GameObject impactEffect;
    private List<GameObject> impacts;

	private void Start() {
        impacts = new List<GameObject>();
    }

	public GameObject GetImpact() {
        foreach (GameObject impact in impacts) {
            if (!impact.activeInHierarchy) {
                impact.SetActive(true);
                return impact;
            }
        }

        GameObject effectInstance = Instantiate(impactEffect, transform);
        impacts.Add(effectInstance);

        return effectInstance;
    }
}
