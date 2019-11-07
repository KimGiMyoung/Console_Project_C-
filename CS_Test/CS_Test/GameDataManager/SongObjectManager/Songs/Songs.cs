using System.Collections.Generic;

class Songs
{
	// 모든 노래 저장 그리고 맞는 노래 반환 클래스

	// 노래 저장 테이블
	Dictionary<SONG_KEY, int[]> _songsTable = new Dictionary<SONG_KEY, int[]>();

	public Songs()
	{
		InitSongs();
	}

	public void InitSongs()
	{
		// 노래 저장하는 방법 int의 부호포함 앞 4비트 제외 나머지 28 비트에 4비트 씩 음표위치와 모양 저장
		// 수정본 2차
		// 0000 빈곳(0)
		// 0001 Q위치 음표(1)	0010 스피드 다운 음표(2)		0011 스피드 업 음표(3)
		// 0100 W위치 음표(4)	0101 스피드 다운 음표(5)		0110 스피드 업 음표(6)
		// 0111 E위치 음표(7)	1000 스피드 다운 음표(8)		1001 스피드 업 음표(9)
		// 1010 R위치 음표(A)	1011 스피드 다운 음표(B)		1100 스피드 업 음표(C)
		// 1101 T위치 음표(D)	1110 스피드 다운 음표(E)		1111 스피드 업 음표(F)
		// 노래 끝 배열 끝
		_songsTable[SONG_KEY.SONG_1] = new int[5] { 0x00070414, 0x07790446, 0x007DF070, 0x04147780, 0x04474171 };
		_songsTable[SONG_KEY.SONG_2] = new int[10] { 0x000D770A, 0x0440147A, 0x0DDF0D77, 0x07A44017, 0x0DD77904, 0x04444760, 0x077777D9, 0x00D780A4, 0x05014DD7, 0x07700000 };

		// 기타 등등 노래
	}

	public int[] GetSong()
	{
		// 게임 노래키 에 맞는 값 반환
		return _songsTable[SongKey.GameSongKey];
	}
}
