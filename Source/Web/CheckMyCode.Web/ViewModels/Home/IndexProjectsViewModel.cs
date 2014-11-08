using CheckMyCode.Data.Models;
using CheckMyCode.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckMyCode.Web.ViewModels.Home
{
    public class IndexProjectsViewModel : IMapFrom<Project>
    {
        public string Name { get; set; }
    }
}