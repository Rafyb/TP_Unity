using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    [SerializeField] private LayerMask layer;

    public GameObject prefab_cube;

    // Start is called before the first frame update
    void Start()
    {
        #if UNITY_EDITOR
                Debug.Log("Unity Editor");
        #elif UNITY_ANDROID
            Debug.Log("Unity Android");
        #elif UNITY_IOS
            Debug.Log("Unity iPhone");
        #else
            Debug.Log("Any other platform");
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) { // nombre de touchers sur l'écran
            Touch touch = Input.GetTouch(0); // récupère le premier toucher

            Vector2 touchPos = touch.position; // position du toucher en coordonnées écran

            Debug.Log("Touch");

            Ray rayon= Camera.main.ScreenPointToRay(touchPos);

            if (Physics.Raycast(rayon, out RaycastHit hit, Mathf.Infinity, layer))
            {
                Debug.Log(hit.point);
                GameObject.Instantiate(prefab_cube, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.LookRotation(hit.normal) );
            }

            /*switch (touch.phase) // vérifie la phase du toucher
            {
                case TouchPhase.Began: // le toucher commence
                    break;
                case TouchPhase.Moved: // le toucher se déplace
                    break;
                case TouchPhase.Ended: // le toucher se termine
                    break;
            }*/
        }
    }
}
