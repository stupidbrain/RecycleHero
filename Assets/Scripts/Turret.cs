using UnityEngine;
using System.Collections;
using EZObjectPools;

public class Turret : MonoBehaviour {

	GameObject Enemy;
	public GameObject HeadPivot;
	public Transform shootPoint;
	public float shootInterval = 0.5f;
	public float damage;
	float nextShootTime = 0;
	public float range=5;
	private AudioSource AS;
	public AudioClip shootSound;
	public EZObjectPool bulletPool;
    public string bulletPoolName;
    //Animator anim;

    void Start () {
		AS = GetComponent<AudioSource> ();
        //anim = GetComponent<Animator>();
        bulletPool = GameObject.Find(bulletPoolName).GetComponent<EZObjectPool>();
        Debug.Log(gameObject);
	}

	void Update () {
		if (Time.time >= nextShootTime) {
			Enemy =  FindClosestTarget(transform.position,range,"Enemy");
			if (Enemy != null){
				HeadPivot.transform.LookAt (Enemy.transform.position);
				Shoot ();
				nextShootTime =Time.time + shootInterval; 
			}
		}
	}

	void Shoot() {
		AS.PlayOneShot (shootSound);
        //anim.SetTrigger("stomping");
            
        GameObject myBullet;
		if (bulletPool.TryGetNextObject(shootPoint.position, shootPoint.rotation, out myBullet)) {
			myBullet.SendMessage ("SetTarget", Enemy);
			myBullet.SendMessage ("SetDamage", damage);
		}
	}

	GameObject FindClosestTarget(Vector3 location, float radius, string targetTag)
	{
		GameObject closest = null;
		float distance = Mathf.Infinity;
		int layerMask = LayerMask.GetMask(targetTag);

		foreach (var thing in Physics.OverlapSphere(location, radius, layerMask))
		{
			float calcDistance = Vector3.Distance(transform.position, thing.transform.position);

			if (distance > calcDistance)
			{
				distance = calcDistance;
				closest = thing.gameObject;
			}
		}
		return closest;
	}
}