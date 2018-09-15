namespace LFramework
{
    public static class Utility
    {
        /// <summary>
        /// 是否为移动平台
        /// </summary>
        /// <returns></returns>
        public static bool IsMobilePlatform()
        {
#if UNITY_ANDROID || UNITY_IOS
        return true;
#else
            return false;
#endif
        }
    }
}