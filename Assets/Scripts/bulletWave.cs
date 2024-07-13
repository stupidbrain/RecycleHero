using System.Collections;
using UnityEngine;

public class bulletWave : MonoBehaviour {

    GameObject target;
    public float speed = 30;
    float damage = 1;

    void OnEnable()
    {
        target = null;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == target)
        {
            col.gameObject.SendMessage("Hit", damage, SendMessageOptions.DontRequireReceiver);
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            //transform.localScale -= new Vector3(0f, 0f, -0.3f);
        }
        else
            gameObject.SetActive(false);
    }

    void SetTarget(GameObject myTarget)
    {
        target = myTarget;
    }

    void SetDamage(float power)
    {
        damage = power;
    }
}

