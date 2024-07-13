using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildManager : MonoBehaviour
{

    public GameObject turret;
    public AudioClip buildSound;
    public LayerMask layer;
    public GameObject displayBlock;
    public AudioClip highlightSound;
    public AudioClip failedSound;

    bool startBuild = false;
    int turretPrice;
    GameObject newTurret;
    AudioSource AS;

    GameObject block;

    List<GameObject> blocklist;
    public Dictionary<GameObject, Turret> blockTurret = new Dictionary<GameObject, Turret>();

    void Start()
    {
        AS = GetComponent<AudioSource>();
        displayBlock.SetActive(false);
        block = null;

        blocklist = new List<GameObject>(GameObject.FindGameObjectsWithTag("Block"));

        foreach (GameObject _block in blocklist)
        {
            _block.GetComponent<MeshRenderer>().enabled = false;
            blockTurret.Add(_block, null);
        }
    }

    void Update()
    {

        if (Input.touchCount == 1 && startBuild)
        {

            Touch touch = Input.GetTouch(0);

            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.green);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, layer))
            {
                if (startBuild)
                    newTurret.transform.position = hit.point;
                if (hit.transform.tag == "Block")
                {
                    if (block == null || block != hit.transform.gameObject)
                    {
                        block = hit.transform.gameObject;
                        AS.PlayOneShot(highlightSound);
                        displayBlock.SetActive(true);
                        displayBlock.transform.position = block.transform.position;
                    }
                }
                else
                    HideBlock();
            }
            else
                HideBlock();

            if (touch.phase == TouchPhase.Ended)
            {
                if (block != null && startBuild)
                {
                    Turret occupiedTurret;
                    occupiedTurret = blockTurret[block];
                    if (occupiedTurret==null)
                    {
                        newTurret.GetComponent<Turret>().enabled = true;
                        newTurret.transform.position = block.transform.position;
                        blockTurret[block] = newTurret.GetComponent<Turret>();
                        MoneyCount.UpdateMoney(-turretPrice);
                        AS.PlayOneShot(buildSound);
                    }
                    else
                    {
                        Destroy(newTurret);
                        AS.PlayOneShot(failedSound);
                    }
                }
                else
                {
                    Destroy(newTurret);
                    AS.PlayOneShot(failedSound);
                }
                HideBlock();
                startBuild = false;
            }
        }
    }

    public void StartBuild(GameObject turretType)
    {
        if (MoneyCount.money >= turretPrice && !startBuild)
        {
            startBuild = true;
            newTurret = Instantiate(turretType, transform.position, Quaternion.identity) as GameObject;
        }
    }

    public void SetPrice(int price)
    {
        turretPrice = price;
    }

    void HideBlock()
    {
        displayBlock.SetActive(false);
        block = null;
    }
}
