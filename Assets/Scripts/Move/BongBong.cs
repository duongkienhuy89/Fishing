using UnityEngine;
using System.Collections;

public class BongBong : MonoBehaviour {

    public float speed;
    float numColorA = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        if (this.transform.position.y > 0)
        {
            if (numColorA > 0)
            {
                numColorA = numColorA - 0.02f;
                
            }
            else
            {
                this.transform.position = new Vector3(UnityEngine.Random.Range(-300, 300), UnityEngine.Random.Range(-900, -600), this.transform.position.z);
                numColorA = 1f;
            }
            this.gameObject.GetComponent<tk2dSprite>().color = new Color(this.gameObject.GetComponent<tk2dSprite>().color.r, this.gameObject.GetComponent<tk2dSprite>().color.g, this.gameObject.GetComponent<tk2dSprite>().color.b, numColorA);
        }
	}
}
