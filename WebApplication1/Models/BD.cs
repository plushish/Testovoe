//namespace WebApplication1.Models
//{
//    public class BD : BaseDto
//    {
//        public required string NameFull { get; set; }
//        public required string NameShort { get; set; }
//        public required int INN { get; set; }
//        public required string OGRN { get; set; }
//        public required DateOnly CreationDate { get; set; }
//        public required DateOnly ChangeDate { get; set; }
//    }
//}
using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class BD
    {
        public int ID { get; set; }
        public required string NameFull { get; set; }
        public required string NameShort { get; set; }
        public required string INN { get; set; }
        public required string OGRN { get; set; }
        public required DateOnly CreationDate { get; set; }
        public required DateOnly ChangeDate { get; set; }

        //public ICollection<Enr> Enrollments { get; set; }
    }
}