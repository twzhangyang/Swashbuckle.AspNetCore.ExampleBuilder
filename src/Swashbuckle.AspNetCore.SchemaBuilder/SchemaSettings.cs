namespace Swashbuckle.AspNetCore.SchemaBuilder
{
    public class SchemaSettings
    {
        public SchemaSettings()
        {
            CamelCase = true;
        } 
        
        public bool CamelCase { get; set; }
    }
}