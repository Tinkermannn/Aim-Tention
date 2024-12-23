using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetShooter : MonoBehaviour
{
    [SerializeField] Camera cam;
    public GameObject muzzlehEffect;
    void Update() {
        if(Input.GetMouseButtonDown(0)) {
                    muzzlehEffect.GetComponent<ParticleSystem>().Play();

            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            if(Physics.Raycast(ray, out RaycastHit hit)) {
                Target target = hit.collider.gameObject.GetComponent<Target>();
                
                if(target != null) {
                    target.Hit();
                }
            }
        }
    }
}
