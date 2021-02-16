using System;
using RecrutaTi.Domain.Enums;

namespace RecrutaTi.Domain.Entities.ValueObjects
{
    public class SocialNetWorkAddress
    {
        public SocialNetWork SocialNetWork { get; set; }
        public Uri Uri { get; set; }
    }
}