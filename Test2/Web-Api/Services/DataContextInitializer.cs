using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Web_Api.Services
{
    public class DataContextInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {

    }
}