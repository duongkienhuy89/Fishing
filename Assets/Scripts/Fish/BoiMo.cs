using UnityEngine;
using System.Collections;

public class BoiMo : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        if (this.transform.position.x > 800)
        {
            this.transform.position = new Vector3(UnityEngine.Random.Range(-1000, -500), this.transform.position.y, this.transform.position.z);
            this.gameObject.GetComponent<tk2dSprite>().color = new Color(1, 1, 1, UnityEngine.Random.Range(0.3f,1f));
            float pScale=UnityEngine.Random.Range(0.5f,1f);
            this.gameObject.GetComponent<tk2dSprite>().scale = new Vector3(pScale, pScale, 1);
            int chon = UnityEngine.Random.Range(0, 5);
            if (chon == 0)
            {
                this.gameObject.GetComponent<tk2dSprite>().SetSprite("mo2");
            }
            else if (chon == 1)
            {
                this.gameObject.GetComponent<tk2dSprite>().SetSprite("mo3");
            }
            else
            {
                this.gameObject.GetComponent<tk2dSprite>().SetSprite("mo1");
            }
        }
	}
}
