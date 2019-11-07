class SceneManager
{
	static Scene_Start _start = new Scene_Start();
	static Scene_Play _play = new Scene_Play();
	static Scene_End _end = new Scene_End();

	public void CurrentScene(SCENE scene)
	{
		// 현재 씬으로 넘겨주는 함수
		switch (scene)
		{
			case SCENE.SCENE_START:
				_start.Run();
				break;
			case SCENE.SCENE_PLAY:
				_play.Run();
				break;
			case SCENE.SCENE_END:
				_end.Run();
				break;
		}
	}
}
