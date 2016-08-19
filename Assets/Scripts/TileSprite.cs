using UnityEngine;
using System.Collections;


public class TileSprite : MonoBehaviour {

	public Sprite tiledSprite;

	public int width;
	public int height;

	// Use this for initialization
	void Start () {

		// This is the template tile that we will copy.
		var spritePrefab = new GameObject ("tile");
		var spritePrefabRenderer = spritePrefab.AddComponent<SpriteRenderer> ();
		spritePrefabRenderer.sprite = tiledSprite;


		var spriteWidth = tiledSprite.bounds.size.x;
		var spriteHeight = tiledSprite.bounds.size.y;



		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {

				var position = transform.position + new Vector3 (spriteWidth * x, -spriteHeight * y);

				var tile = GameObject.Instantiate (spritePrefab, transform) as GameObject;
				tile.transform.position = position;

			}
		}


		DestroyImmediate (spritePrefab);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
