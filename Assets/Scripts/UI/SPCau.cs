using UnityEngine;
using System.Collections;

public class SPCau : MonoBehaviour {



    public LuoiCau luoicau;





    public void setLuoiCau()
    {
        try
        {
        luoicau.setQuay();
        }
        catch (System.Exception)
        {


            throw;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
