
namespace MapSellTypeOptions { 
    public struct MapSellType
    {
        public const int Normal = 0;
        public const int Transparency = 1;
        public const int Wall = 2;
        private static readonly int[] typeCompareArray = { Normal, Transparency, Wall };
        private static readonly string[] typeNameArray = { "Normal", "Transparency", "Wall" };

        public int sellTypeCode;
        
        //코드를 비교합니다
        public bool CompareCode(int code)
        {
            return sellTypeCode == code;
        }

        public void SetType(int code)
        {
            if (!ChackType(code)) return;

            sellTypeCode = code;
        }

        //입력받은 코드의 MapSellType 에 맞는 이름을 반환합니다
        public static string GetTypeName(int code)
        {
            if (!ChackType(code)) return "";
            return typeNameArray[code];
        }

        //입력받은 코드가 MapSellType 형식에 유효한지 검사합니다
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
