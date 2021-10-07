using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using EzySlice;
using UnityEngine;

public class MovementInput : MonoBehaviour
{
    public CharacterController controller;
    public float moveSpeed = 5f;
    public float rotateSpeed = 1f;
    public GameObject planeCut;
    public LayerMask layerCut;
    
    private Animator anim;
    private Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        anim = GetComponent<Animator>();
    }

    void CreatePieceComponent(GameObject go)
    {
        go.layer = LayerMask.NameToLayer("destroyable");
        Rigidbody rb = go.AddComponent<Rigidbody>();
        MeshCollider collider = go.AddComponent<MeshCollider>();
        collider.convex = true;
        rb.AddExplosionForce(100,go.transform.position,20);
    }

    void UpdateX(float x)
    {
        anim.SetFloat("X",x);
    }
    
    void UpdateY(float y)
    {
        anim.SetFloat("Y",y);
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        
        
        Vector3 foward = cam.transform.forward;
        Vector3 right = cam.transform.right;
        foward.y = 0f;
        right.y = 0f;
        foward.Normalize();
        right.Normalize();

        Vector3 moveDir = foward * inputZ + right * inputX;
        float intensity = moveDir.magnitude;
        
        if (inputZ != 0f)
        {
            controller.Move(moveDir*Time.deltaTime*moveSpeed);
        }
        
        anim.SetFloat("Move",intensity,0.1f,Time.deltaTime);

        
        
        
        if(intensity > 0.3f) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir),Time.deltaTime*rotateSpeed );

        if (Input.GetMouseButtonDown(1))
        {
            Time.timeScale = 0.2f;
            
            planeCut.SetActive(true);
            
            cam.DOKill();
            cam.DOFieldOfView(40, 0.3f);
        }

        if (Input.GetMouseButton(1))
        {
            
            
            planeCut.transform.eulerAngles += new Vector3(0, 0, -Input.GetAxis("Mouse X")*5);

            float angleZ = planeCut.transform.eulerAngles.z;
            float x = Mathf.Cos(angleZ * Mathf.Deg2Rad);
            float y = Mathf.Sin(angleZ * Mathf.Deg2Rad);
            
            anim.SetFloat("X",x);
            anim.SetFloat("Y",y);
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("bladeMode",true);
            
            float angleZ = planeCut.transform.eulerAngles.z;
            float x = Mathf.Cos(angleZ * Mathf.Deg2Rad);
            float y = Mathf.Sin(angleZ * Mathf.Deg2Rad);

            DOVirtual.Float(x, -x, 0.2f, UpdateX);
            DOVirtual.Float(y, -y, 0.2f, UpdateY);
            
            Collider[] hits = Physics.OverlapBox(planeCut.transform.position, new Vector3(10f, 0.1f, 10),
                planeCut.transform.rotation, layerCut);
            foreach (var item in hits)
            {
                SlicedHull hull = item.gameObject.Slice(planeCut.transform.position, planeCut.transform.up);
                if (hull != null)
                {
                    GameObject bottom = hull.CreateLowerHull(item.gameObject, null);
                    GameObject top = hull.CreateUpperHull(item.gameObject, null);
                    CreatePieceComponent(top);
                    CreatePieceComponent(bottom);
                    Destroy(item.gameObject);
                }
            }

        }

        if (Input.GetMouseButtonUp(1))
        {
            Time.timeScale = 1f;
            
            planeCut.SetActive(false);
            planeCut.transform.eulerAngles += new Vector3(0, 0, 0);
            
            cam.DOKill();
            cam.DOFieldOfView(60, 0.1f);
        }
    }
}
