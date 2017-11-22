using UnityEngine;

public class Zombie_Creator : MonoBehaviour
{

    private GameObject tinyZombie;
    private GameObject player;
    private GameObject portal;
    private GameObject fireFiles;
    private int maxNumTinyZombie;
    private int numTinyZombie;


    // Use this for initialization
    void Start()
    {
        InitializeTinyZombie();
    }
	
	// Update is called once per frame
	void Update()
    {
		if(numTinyZombie < maxNumTinyZombie)
        {
            CreateTinyZombie();
        }
	}

    private void InitializeTinyZombie()
    {
        maxNumTinyZombie = 10;
        numTinyZombie = 0;
        tinyZombie = Resources.Load<GameObject>("Create/TinyZombie");
        player= GameObject.Find("/Player/Cha_Knight");
        portal = Resources.Load<GameObject>("TornadoBanditsStudio/Low Poly Free Pack/Prefabs/Particles/Portal_Orb");
        fireFiles = Resources.Load<GameObject>("TornadoBanditsStudio/Low Poly Free Pack/Prefabs/Particles/Particles_Fireflies");
    }
    private void CreateTinyZombie()
    {
        Vector3 createdPos = RandomPosition();
        GameObject created = Instantiate(tinyZombie, createdPos, tinyZombie.transform.rotation);
        created.transform.parent = gameObject.transform;
        GameObject mummy = created.transform.Find("mummy_rig").gameObject;
        CreatePortal(new Vector3(mummy.transform.position.x, mummy.transform.position.y + 2.08f, mummy.transform.position.z -1.08f));    
    }
    public void CreatePortal(Vector3 createdPos)
    {
        Instantiate(portal, createdPos, portal.transform.rotation); 
    }
    public void CreateFireFiles(Vector3 createdPos)
    {
        Instantiate(fireFiles, createdPos, fireFiles.transform.rotation);
    }
    private Vector3 RandomPosition()
    {
        //float dist = 9.0f;
        //Vector3 randPos;
        //do
        //{
        //    randPos = new Vector3(player.transform.position.x + Random.Range(-dist, dist), 0, player.transform.position.z + Random.Range(-dist, dist));

        //} while (dist < Vector3.Distance(randPos, player.transform.position));

        //return randPos;

        float minPosX = -17.63f, maxPosX = 30.8f, minPosZ = -14.79f, maxPosZ = 10.66f;
        return new Vector3(Random.Range(minPosX, maxPosX), 0, Random.Range(minPosZ, maxPosZ));
    }
    public void IncreaseNumberOfTinyZombie()
    {
        numTinyZombie++;
    }
    public void DecreaseNumberOfTinyZombie()
    {
        numTinyZombie--;
    }
}
