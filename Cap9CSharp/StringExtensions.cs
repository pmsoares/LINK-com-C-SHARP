namespace Cap9CSharp
{
    public static class StringExtensions
    {
        public static bool IsEmptyAfterTrim( this string str )
        {
            string aux = str;
            if( aux == null )
            {
                return true;
            }
            return string.IsNullOrEmpty( str.Trim() );
        }
    }
}