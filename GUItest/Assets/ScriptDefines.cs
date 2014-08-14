using UnityEngine;
using System.Collections;

public class ScriptDefines : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		#if UNITY_TIZEN
			Debug.Log ("Tizen Script define fired");
		#endif

		#if UNITY_BLACKBERRY
			Debug.Log ("Blackberry Script define fired");
		#endif



	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
