using System;
using SharpMongoDB.Core.Enums;

namespace SharpMongoDB.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FetchTypeAttribute
    {
        public FetchTypeAttribute(FetchTypeEnum fetchType)
        {
            
        }
    }
}