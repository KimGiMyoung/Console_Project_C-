// 노래키 enum과 클래스
enum SONG_KEY
{
	SONG_1,
	SONG_2,

	MAX,
}

static class SongKey
{
	static public SONG_KEY GameSongKey = SONG_KEY.SONG_1;

	static public string[] SongName = new string[(int)SONG_KEY.MAX] { "비행기", "나비야" };
	static public char[] SongObjectC = new char[6] { '■', '▼', '▲', '□', '▽', '△' };
}
