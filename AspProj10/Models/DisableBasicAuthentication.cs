using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace AspProj10.Models
{
    public class DisableBasicAuthentication : Attribute, IFilterMetadata
    {
    }
}
