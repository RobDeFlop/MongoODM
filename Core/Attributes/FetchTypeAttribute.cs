using System;
using SharpMongoDB.Core.Enums;

namespace SharpMongoDB.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FetchTypeAttribute: Attribute
    {
        public FetchTypeAttribute(FetchType fetchType)
        {
            
        }
    }
}