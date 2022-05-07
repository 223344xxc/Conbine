
namespace MapSellTypeOptions { 
    public struct MapSellType
    {
        #region TileDefine
        public const int Normal = 0;
        public const int Transparency = 1;
        public const int Wall = 2;
        public const int Lock = 3;
        public const int BlackHole = 4;

        public static readonly int[] typeCompareArray = 
            { Normal, Transparency, Wall, Lock, BlackHole};

        public static readonly string[] typeNameArray = 
            { "Normal", "Transparency", "Wall", "Lock", "BlackHole"};
        #endregion

        public int sellTypeCode;
        
        /// <summary>
        /// 맵 타일 코드를 비교합니다.
        /// </summary>
        /// <param name="code"> 맵 타일 코드 </param>
        /// <returns></returns>
        public bool CompareCode(int code)
        {
            return sellTypeCode == code;
        }

        public void SetType(int code)
        {
            if (!ChackType(code)) return;

            sellTypeCode = code;
        }

        /// <summary>
        /// 입력받은 코드의 MapSellType 에 맞는 이름을 반환합니다.
        /// </summary>
        /// <param name="code"> 맵 타일 코드 </param>
        /// <returns></returns>
        public static string GetTypeName(int code)
        {
            if (!ChackType(code)) return "";
            return typeNameArray[code];
        }

        /// <summary>
        /// 입력받은 코드가 MapSellType 형식에 유효한지 검사합니다.
        /// </summary>
        /// <param name="code"> 맵 타일 코드 </param>
        /// <returns></returns>
        private static bool ChackType(int code)
        {
            for(int i = 0; i < typeCompareArray.Length; i++)
            {
                if (typeCompareArray[i] == code)
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            return sellTypeCode.ToString();
        }
    }
}
