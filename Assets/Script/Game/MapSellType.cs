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
        public bool canStand;


        public MapSellInfo(int typeCode, string typeName, string spriteName, string animatorName, Color sellColor, bool canStand)
        {
            this.typeCode = typeCode;
            this.typeName = typeName;
            this.spriteName = spriteName;
            this.animatorName = animatorName;
            this.sellColor = sellColor;
            this.canStand = canStand;
        }

        /// <summary>
        /// 맵 타일 빌더 입니다.
        /// </summary>
        public struct Builder {
            MapSellInfo info;
            
            public Builder setTypeCode(int code)
            {
                info.typeCode = code;
                return this;
            }

            public Builder setTypeName(string name)
            {
                info.typeName = name;
                return this;
            }

            public Builder setSpriteName(string name)
            {
                info.spriteName = name;
                return this;
            }

            public Builder setAnimatorName(string name)
            {
                info.animatorName = name;
                return this;
            }

            public Builder setColor(Color color)
            {
                info.sellColor = color;
                return this;
            }

            public Builder setStand(bool stand)
            {
                info.canStand = stand;
                return this;
            }
            public MapSellInfo Build()
            {
                return info;
            }
        }
    }

    /// <summary>
    /// 맵 타일의 타입에 대한 처리를 위한 구조체 입니다.
    /// </summary>
    public struct MapSellType
    {
        #region 맵 타일 정의
        public static readonly MapSellInfo NORMAL_SELL =
            new MapSellInfo.Builder().
            setTypeCode(0).
            setTypeName("Normal").
            setSpriteName("MapSell_Default").
            setAnimatorName("DefaultSellController").
            setColor(new Color(0.0f, 0.56f, 0.56f, 1)).
            setStand(true).
            Build();

        public static readonly MapSellInfo TRANSPARENCY_SELL =
            new MapSellInfo.Builder().
            setTypeCode(1).
            setTypeName("Transparency").
            setSpriteName("MapSell_Default").
            setAnimatorName("DefaultSellController").
            setColor(new Color(1.0f, 1.0f, 1.0f, 0.0f)).
            setStand(false).
            Build();

        public static readonly MapSellInfo WALL_SELL =
            new MapSellInfo.Builder().
            setTypeCode(2).
            setTypeName("Wall").
            setSpriteName("MapSell_Lock").
            setAnimatorName("DefaultSellController").
            setColor(new Color(0.3f, 0.3f, 0.3f, 1.0f)).
            setStand(false).
            Build();

        public static readonly MapSellInfo LOCK_SELL =
            new MapSellInfo.Builder().
            setTypeCode(3).
            setTypeName("Lock").
            setSpriteName("MapSell_Lock").
            setAnimatorName("LockSellController").
            setColor(Color.white).
            setStand(false).
            Build();

        public static readonly MapSellInfo LOCK_OPEN_SELL =
            new MapSellInfo.Builder().
            setTypeCode(4).
            setTypeName("LockOpen").
            setSpriteName("MapSell_LockOpen").
            setAnimatorName("LockOpenSellController").
            setColor(new Color(0.3f, 0.3f, 0.3f, 0.7f)).
            setStand(true).
            Build();

        public static readonly MapSellInfo BLACKHOLE_SELL =
            new MapSellInfo.Builder().
            setTypeCode(5).
            setTypeName("BlackHole").
            setSpriteName("MapSell_Default").
            setAnimatorName("BlackHoleSellController").
            setColor(Color.white).
            setStand(true).
            Build();

        public static readonly MapSellInfo PROTAL_SELL =
            new MapSellInfo.Builder().
            setTypeCode(6).
            setTypeName("Portal").
            setSpriteName("MapSell_Default").
            setAnimatorName("DefaultSellController").
            setColor(Color.green).
            setStand(true).
            Build();

        #endregion

        public static readonly MapSellInfo[] MAP_SELL_INFO_ARRAY = {
            NORMAL_SELL,
            TRANSPARENCY_SELL,
            WALL_SELL,
            LOCK_SELL,
            LOCK_OPEN_SELL,
            BLACKHOLE_SELL,
            PROTAL_SELL,
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
        public static bool ChackType(int code)
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

        public bool CanMove()
        {
            if (!ChackType(sellTypeCode))
                return false;

            return MAP_SELL_INFO_ARRAY[sellTypeCode].canStand;
        }

        public bool CanOut()
        {
            if (CompareCode(BLACKHOLE_SELL.typeCode))
                return false;

            return true;
        }

        public override string ToString()
        {
            return sellTypeCode.ToString();
        }
    }
}
