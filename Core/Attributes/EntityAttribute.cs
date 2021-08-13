using System;

namespace SharpMongoDB.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EntityAttribute : Attribute
    {
        public EntityAttribute(Type classType)
        {
            ClassType = classType;
        }

        public Type ClassType { get; set; }
    }
}