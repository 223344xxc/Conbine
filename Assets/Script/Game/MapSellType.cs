using UnityEngine;


namespace MapSellDataDefine
{
    /// <summary>
    /// 맵 타일의 색을 정의한 클래스 입니다.
    /// </summary>
    public class MapSellColor
    {
        public static Color NORMAL_SELL_COLOR = new Color(0.0f, 0.56f, 0.56f, 1);
        public static Color TRANSPARENCY_SELL_COLOR = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        public static Color WALL_SELL_COLOR = new Color(0.3f, 0.3f, 0.3f, 1.0f);
        public static Color LOCK_SELL_COLOR = Color.white;
        public static Color BLACKHOLE_SELL_COLOR = Color.white;

        public static readonly Color[] mapSellColorArray = {
            NORMAL_SELL_COLOR,
            TRANSPARENCY_SELL_COLOR,
            WALL_SELL_COLOR,
            LOCK_SELL_COLOR,
            BLACKHOLE_SELL_COLOR
        };
    }
}

namespace MapSellTypeOptions {
  
    /// <summary>
    /// 맵 타일의 타입에 대한 처리를 위한 구조체 입니다.
    /// </summary>
    public struct MapSellType
    {
        #region TileDefine
        public const int NORMAL = 0;
        public const int TRANSPARENCY = 1;
        public const int WALL = 2;
        public const int LOCK = 3;
        public const int BLACKHOLE = 4;

        public static readonly int[] typeCompareArray = 
            { NORMAL, TRANSPARENCY, WALL, LOCK, BLACKHOLE};

        public static readonly string[] typeNameArray = 
            { "Normal", "Transparency", "Wall", "Lock", "BlackHole"};

        #region 맵 스프라이트 이름 정보
        public static string DEFAULT_MAP_SELL_SPRITE = "MapSell_Default";
        public static string TRANSPARENCY_MAP_SELL_SPRITE = "MapSell_Default";
        public static string WALL_MAP_SELL_SPRITE = "MapSell_Default";
        public static string LOCK_MAP_SELL_SPRITE = "MapSell_Lock";
        public static string BLACKHOLE_MAP_SELL_SPRITE = "MapSell_Default";
   

        public static readonly string[] typeSpriteNameArray = { 
            DEFAULT_MAP_SELL_SPRITE, 
            TRANSPARENCY_MAP_SELL_SPRITE,
            WALL_MAP_SELL_SPRITE,
            LOCK_MAP_SELL_SPRITE,
            BLACKHOLE_MAP_SELL_SPRITE
        };
        #endregion
        #endregion

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

            return MapSellDataDefine.MapSellColor.mapSellColorArray[code];
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

        /// <summary>
        /// 입력받은 코드에 맞는 맵 타일의 스프라이트 이름을 반환합니다.
        /// </summary>
        /// <param name="code"> 타일 코드 </param>
        public static string GetMapSellSpriteName(int code)
        {
            if (!ChackType(code))
                return string.Empty;

            return typeSpriteNameArray[code];
        }

        public override string ToString()
        {
            return sellTypeCode.ToString();
        }
    }
}
