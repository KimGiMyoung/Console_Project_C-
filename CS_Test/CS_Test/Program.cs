using System;
using System.Collections.Generic;

class Program
{
	static void Main(string[] args)
	{
		Console.CursorVisible = false;
		SceneManager sm = new SceneManager();
		sm.CurrentScene(SCENE.SCENE_START);
	}
}
