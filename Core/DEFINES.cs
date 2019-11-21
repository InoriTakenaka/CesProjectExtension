
namespace Core
{
    /* enum for inspection method */
    public static class ISPMSD
    {
        public const string X1 = "双怠速";
        public const string X2 = "稳态工况";
        public const string X3 = "瞬态工况";
        public const string X4 = "不透光烟度";
        public const string X5 = "加载减速";
        public const string X6 = "滤纸式烟度";
		public const string REG = "注册登记检验";
    }

    public static class MSDCODE
    {
        public const int X1 = 15;
        public const int X2 = 25;
        public const int X3 = 28;
        public const int X4 = 23;
        public const int X5 = 26;
        public const int X6 = 24;
		public const int OB = 25;
    }
    public static class INSTRU
    {
        public const string CGJ = "G1";
        public const string FXY = "F1";
        public const string YDJ = "Y1";
        public const string LZS = "Y2";
        public const string OBD = "OB";
    }
    ///* 1- XC_CY 2- XC_QY 3- ZY-CY 4- ZY-QY */
    public static class DOCTYPE
    {
        public const int XC_CY = 1;
        public const int XC_QY = 2;
        public const int ZY_CY = 3;
        public const int ZY_QY = 4;
    }
}
