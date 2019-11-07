// 신 종류 enum
enum SCENE
{
	SCENE_START,
	SCENE_PLAY,
	SCENE_END,
}

// 시작화면 그리는 위치 enum 매직넘버 없애기 위함
enum SCENE_START_POS
{
	SCENE_START_POS_X = 5,	// 시작 UI 그리는 위치 x

	CUR_POS_X = 3,			// 커서 위치 x
	CUR_POS_Y = 3,			// 커서 위치 y

	SONG_POS_Y = 3,			// 노래 선택 UI 위치 y
	SPEED_POS_Y = 4,		// 스피드 선택 UI 위치 y
	GAME_POS_Y = 5,			// 게임 시작 선택 UI 위치 y
}

// 게임화면 그리는 위치 enum 매직넘버 없애기 위함
enum SCENE_GAME_POS
{
	SCENE_GAME_POS_X = 0,
	SCENE_GAME_POS_Y = 0,

	CUR_POS_Y = 19,

	GAME_SPEED_POS_X = 0,
	GAME_SPEED_POS_Y = 20,
}

// 종료화면 그리는 위치 enum 매직넘버 없애기 위함
enum SCENE_END_POS
{
	SCENE_END_POS_X = 5,

	CUR_POS_X = 3,
	CUR_POS_Y = 4,

	GAME_OVER_POS_Y = 3,
	GAME_RESTART_POS_Y = 4,
	GAME_END_POS_Y = 5,
}
