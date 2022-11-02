namespace WPFcharacterictic.Core.Extensions
{
    public static class ListExtensions
    {
        public static List<T> GetShallowCopy<T>(this List<T> origin)
        {
            var dest = new List<T>();
            
            foreach (var i in origin)
            {
                dest.Add(i);
            }

            return dest;
        }
    }
}
