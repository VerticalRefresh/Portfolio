using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Barham_C971.DataClasses
{
    public class Student
    {
        [PrimaryKey, AutoIncrement]
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentPassword { get; set; }

    }
}
