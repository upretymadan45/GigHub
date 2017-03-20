using GigHub.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GigHub.Persistance.EntityConfigurations
{
    public class FollowingConfiguration:EntityTypeConfiguration<Following>
    {
        public FollowingConfiguration()
        {

        }
    }
}