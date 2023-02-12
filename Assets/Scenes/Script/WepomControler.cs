using UnityEngine;
using  TMPro;
using StarterAssets;
using System.Collections;

public class WepomControler : MonoBehaviour
{
    [SerializeField] private StarterAssetsInputs starterAssetsInputs;
    [SerializeField] private ParticleSystem hitEfect; 
    [SerializeField] private ParticleSystem hitEfectBlood;
    [SerializeField] private ParticleSystem muzzlef;
    [SerializeField] private LayerMask aimColLayerMask;
    [SerializeField] private TextMeshProUGUI _ammo;
    [SerializeField] private int damage = 15;
    [SerializeField] private AudioClip shootSFX;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float curentAmmo; 
    [SerializeField] private float maxAmmo;
    [SerializeField] private float reloadTime;
    [SerializeField] private Transform hitPos;
    [SerializeField] private AiAttack navMesh;
    public GameObject bullet;
    private float nextFire;
    private bool isReloading=true;
    private Transform hitTransform ;
  
    
    void Start()
    {
        if (curentAmmo == -1)
        { 
            curentAmmo = maxAmmo;
        } 
    }

    // Update is called once per frame
    void Update()
    {
//      _ammo.text ="Ammo:"+ curentAmmo;
    //  if (isReloading)
        {
       //     if (curentAmmo <= 0)
            {
         //       StartCoroutine(Reload());
            }

           // if (starterAssetsInputs.shoot)
            {
//                muzzlef.Play();
              //  if (CompareTag("Enemy"))
                if (Physics.Raycast(hitPos.position,transform.forward, out RaycastHit raycastHit, 999f, aimColLayerMask))
                {
                  
                    hitTransform = raycastHit.transform;
                      navMesh.TakeDamage(damage);
                    Debug.Log("HitEnemy"+hitTransform);
                    
                 //   Instantiate(hitEfectBlood, raycastHit.point, Quaternion.identity);
                }
                else
                {
                    Debug.Log("Hit"+hitTransform);
                    
                  //  Instantiate(hitEfect, raycastHit.point, Quaternion.identity);
                }
            }
           // starterAssetsInputs.shoot = false;
        }
    }   
    IEnumerator Reload()
    {
        isReloading = false;
        Debug.Log("Reload");
        yield return new WaitForSeconds(reloadTime);
        curentAmmo = maxAmmo;   
        
        isReloading =true;
    }
}
