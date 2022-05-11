using UnityEngine;


namespace MapSellTypeOptions {
  
    /// <summary>
    /// 맵 타일 데이터를 정의하는 구조체 입니다.
    /// </summary>
    public struct MapSellInfo
    {
        public int typeCode;
        public string typeName;
        public string spriteName;
        public string animatorName;
        public Color sellColor;

        public MapSellInfo(int typeCode, string typeName, string spriteName, string animatorName, Color sellColor)
        {
            this.typeCode = typeCode;
            this.typeName = typeName;
            this.spriteName = spriteName;
            this.animatorName = animatorName;
            this.sellColor = sellColor;
        }
    }

    /// <summary>
    /// 맵 타일의 타입에 대한 처리를 위한 구조체 입니다.
    /// </summary>
    public struct MapSellType
    {
        public static readonly MapSellInfo NORMAL_SELL = 
            new MapSellInfo(0, "Normal", "MapSell_Default", "DefaultSellController", new Color(0.0f, 0.56f, 0.56f, 1));

        public static readonly MapSellInfo TRANSPARENCY_SELL = 
            new MapSellInfo(1, "Transparency", "MapSell_Default", "DefaultSellController", new Color(1.0f, 1.0f, 1.0f, 0.0f));

        public static readonly MapSellInfo WALL_SELL = 
            new MapSellInfo(2, "Wall", "MapSell_Default", "DefaultSellController", new Color(0.3f, 0.3f, 0.3f, 1.0f));

        public static readonly MapSellInfo LOCK_SELL =
            new MapSellInfo(3, "Lock", "MapSell_Lock", "LockSellController", Color.white);

        public static readonly MapSellInfo BLACKHOLE_SELL = 
            new MapSellInfo(4, "BlackHole", "MapSell_Default", "DefaultSellController", Color.white);


        public static readonly MapSellInfo[] MAP_SELL_INFO_ARRAY = {
            NORMAL_SELL,
            TRANSPARENCY_SELL,
            WALL_SELL,
            LOCK_SELL,
            BLACKHOLE_SELL,
        };

        public int sellTypeCode;
        
        /// <summary>
        /// 입력받은 코드에 맞는 타일의 색을 반환합니다.
        /// </summary>
        /// <param name="code"> 맵 타일 코드 </param>
        /// <returns> MapSellColor 클래스에 정의된 타일 색상 </returns>
        public static Color GetSellColor(int code)
        {
            if (!ChackType(code))
                return Color.white;

            return MAP_SELL_INFO_ARRAY[code].sellColor;
        }

        /// <summary>
        /// 맵 타일 코드를 비교합니다.
        /// </summary>
        /// <param name="code"> 맵 타일 코드 </param>
        /// <returns></returns>
        public bool CompareCode(int code)
        {
            return sellTypeCode == code;
        }

        /// <summary>
        /// 맵 타일 코드를 비교합니다.
        /// </summary>
        /// <param name="info"> 맵 타일 정보 </param>
        /// <returns></returns>
        public bool CompareCode(MapSellInfo info)
        {
            return CompareCode(info.typeCode);
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
            return MAP_SELL_INFO_ARRAY[code].typeName;
        }

        /// <summary>
        /// 입력받은 코드가 MapSellType 형식에 유효한지 검사합니다.
        /// </summary>
        /// <param name="code"> 맵 타일 코드 </param>
        /// <returns></returns>
        private static bool ChackType(int code)
        {
            for(int i = 0; i < MAP_SELL_INFO_ARRAY.Length; i++)
            {
                if (MAP_SELL_INFO_ARRAY[i].typeCode == code)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 입력받은 코드에 맞는 맵 타일의 스프라이트 이름을 반환합니다.
        /// </summary>
        /// <param name="code"> 타일 코드 </param>
        public static string GetMapSellSpriteName(int code)
        {
            if (!ChackType(code))
                return string.Empty;

            return MAP_SELL_INFO_ARRAY[code].spriteName;
        }

        /// <summary>
        /// 입력받은 코드에 맞는 맵 타일의 애니메이터 이름을 반환합니다.
        /// </summary>
        /// <param name="code"> 타일 코드 </param>
        /// <returns></returns>
        public static string GetMapSellAnimatorName(int code)
        {
            if (!ChackType(code))
                return string.Empty;

            return MAP_SELL_INFO_ARRAY[code].animatorName;
        }

        public override string ToString()
        {
            return sellTypeCode.ToString();
        }
    }
}
