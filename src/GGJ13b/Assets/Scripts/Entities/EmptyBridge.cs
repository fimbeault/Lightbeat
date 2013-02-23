using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EmptyBridge : MonoBehaviour {

	public GameObject bridgePart;
	
	private int longeurX = 5; 
	private int longeurY = 5;
	
	public int nbBlocX;
	public int nbBlocY;
	public int scale;
	
	List<GameObject> bridgeParts;
	bool activated = false;

	
	// Use this for initialization
	void Start()
	{	
		bridgeParts = new List<GameObject>();
		
		for(int i = 0; i < nbBlocX; i++){
			for(int j = 0; j < nbBlocY; j++){
				GameObject p = (GameObject)Instantiate(bridgePart,new Vector3((gameObject.transform.position.x + i * longeurX), (gameObject.transform.position.y + j * longeurY),0),Quaternion.identity);
				p.transform.parent = gameObject.transform;
				p.transform.Rotate(270, 0, 0);
				p.transform.localScale = new Vector3(scale * 0.1f , 1, scale * 0.1f);
				p.renderer.enabled = false;
				
				bridgeParts.Add(p);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Toogle()
	{
		if(activated)
		{
			foreach(GameObject part in bridgeParts)
			{
				part.GetComponent<BoxCollider>().enabled = true;
				part.renderer.enabled = false;
			}
			
			activated = false;
		}
		
		else
		{
			foreach(GameObject part in bridgeParts)
			{
				part.GetComponent<BoxCollider>().enabled = false;
				part.renderer.enabled = true;
			}
			
			activated = true;
		}
	}
}
