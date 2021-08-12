using System;

namespace SharpMongoDB.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EntityAttribute: Attribute
    {
        public Type ClassType { get; set; }
        public EntityAttribute(Type classType)
        {
            ClassType = classType;
        }
        
        
    }
}