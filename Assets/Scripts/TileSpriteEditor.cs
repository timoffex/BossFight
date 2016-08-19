using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(TileSprite))]
public class TileSpriteEditor : Editor {

	SerializedProperty tiledSprite;
	SerializedProperty width;
	SerializedProperty height;


	void OnEnable () {
		tiledSprite = serializedObject.FindProperty ("tiledSprite");
		width = serializedObject.FindProperty ("width");
		height = serializedObject.FindProperty ("height");
	}

	void OnSceneGUI () {
		var t = target as TileSprite;

		var spriteWidth = t.tiledSprite.bounds.size.x;
		var spriteHeight = t.tiledSprite.bounds.size.y;

		var startPos = t.transform.position - new Vector3 (spriteWidth*0.5f, -spriteHeight*0.5f, 0);


		var lineWidth = spriteWidth * t.width;
		var lineHeight = spriteHeight * t.height;


		Handles.color = Color.green;

		// Draw vertical lines
		for (int x = 0; x <= t.width; x++) {
			var start = startPos + new Vector3 (x * spriteWidth, 0, 0);
			var end = start - new Vector3 (0, lineHeight, 0);
			Handles.DrawLine (start, end);
		}

		// Draw horizontal lines
		for (int y = 0; y <= t.height; y++) {
			var start = startPos - new Vector3 (0, y * spriteHeight, 0);
			var end = start + new Vector3 (lineWidth, 0, 0);
			Handles.DrawLine (start, end);
		}
	}
}
