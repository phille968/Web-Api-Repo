using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApi.Services
{
    public class DataContextInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {

    }
}