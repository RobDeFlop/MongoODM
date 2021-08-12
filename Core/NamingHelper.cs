namespace SharpMongoDB.Core
{
    public class NamingHelper
    {
        public static string GeneratePluralNaming(string singularName)
        {
            return singularName.ToLower() + "s";
        }
    }
}