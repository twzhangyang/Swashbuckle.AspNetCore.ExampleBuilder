namespace Swashbuckle.AspNetCore.SchemaBuilder
{
    public static class FirstLowercaseExtensions
    {
       public static string FirstLower(this string s)
       {
           if (string.IsNullOrEmpty(s))
           {
               return s;
           }

           return s[0].ToString().ToLower() + s.Substring(1);
       }
    }
}