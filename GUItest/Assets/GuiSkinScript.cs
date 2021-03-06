using UnityEngine;
using System.Collections;

public class GuiSkinScript : MonoBehaviour {

    public GUISkin[] s1;
    public GameObject tdTextObject;
    public GameObject guiTextObject;
    public Font georgiaTTF;
    public Font courTTF;
    private float hSliderValue = 0.0F;
    private float vSliderValue = 0.0F;
    private float hSValue = 0.0F;
    private float vSValue = 0.0F;
    private int cont = 0;
	public Vector2 scrollPosition = Vector2.zero;
	string hSlider = " ";
	string vSlider = " ";
	string outputNumber;
	private float startTime;
  	private float elapsedTime;
	

	/*	
    IEnumerator Start() {
        WWW www = new WWW(url);
        yield return www;
        //renderer.material.mainTexture = www.texture;
    }
	*/

	void Awake()
	{
		startTime = 0;
	}
	
	
	void Update() 
    {
        if (startTime > -1)
		{
			elapsedTime = Time.time - startTime;
		}
		
		if ((Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended) || (Input.GetKeyDown(KeyCode.Space)))
        {
            cont++;

            Debug.Log("Before tdTextObject font name = " + tdTextObject.GetComponent<TextMesh>().font.name);
            Debug.Log("Before guiTextObject font name = " + guiTextObject.guiText.font.name);

            if ((cont % s1.Length) == 1)
            {
                tdTextObject.GetComponent<TextMesh>().font = georgiaTTF;
                guiTextObject.guiText.font = courTTF;
            }
            else
            {
                tdTextObject.GetComponent<TextMesh>().font = courTTF;
                guiTextObject.guiText.font = georgiaTTF;
            }

            Debug.Log("Now tdTextObject font name = " + tdTextObject.GetComponent<TextMesh>().font.name);
            Debug.Log("Now guiTextObject font name = " + guiTextObject.guiText.font.name);
        }
        
    }
    

	void OnMouseDown() {
		Application.OpenURL("http://www.google.com");
		Debug.Log("Weblink button has been pressed");
	}
	
    void OnGUI() 
    {
		
		GUI.skin = s1[cont % s1.Length];
        if (s1.Length == 0) {
            Debug.LogError("Assign at least 1 skin on the array");
            return;
        }
		
		GUI.Label(new Rect (400, 10, 150, 50), (elapsedTime.ToString()));	
       	hSlider = hSliderValue.ToString();
		GUI.Label(new Rect(10, 5, 700, 30), hSlider);
		vSlider = vSliderValue.ToString();
        GUI.Box(new Rect(10, 30, 300, 75), vSlider);
        if (GUI.Button(new Rect(10, 125, 300, 75), "Go to google"))
			this.OnMouseDown();
        
        hSliderValue = GUI.HorizontalSlider(new Rect(10, 400, 300, 90), hSliderValue, 0.0F, 10.0F);
        vSliderValue = GUI.VerticalSlider(new Rect(100, 500, 300, 90), vSliderValue, 10.0F, 0.0F);
        //hSValue = GUI.HorizontalScrollbar(new Rect(10, 350, 300, 90), hSValue, 1.0F, 0.0F, 10.0F);
        //vSValue = GUI.VerticalScrollbar(new Rect(10, 450, 300, 90), vSValue, 1.0F, 10.0F, 0.0F);
		
		scrollPosition = GUI.BeginScrollView(new Rect(700, 10, 200, 200), scrollPosition, new Rect(0, 0, 220, 200));
        GUI.Button(new Rect(0, 0, 100, 20), "Top-left");
        GUI.Button(new Rect(120, 0, 100, 20), "Top-right");
        GUI.Button(new Rect(0, 180, 100, 20), "Bottom-left");
        GUI.Button(new Rect(120, 180, 100, 20), "Bottom-right");
        GUI.EndScrollView();
    }
}
