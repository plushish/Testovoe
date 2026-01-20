namespace WebApplication1.Models
{
    public class BDUpdateDto : BaseDto
    {
        public required string NameFull { get; set; }
        public required string NameShort { get; set; }
        public required string INN { get; set; }
        public required string OGRN { get; set; }
        public required DateOnly CreationDate { get; set; }
        public required DateOnly ChangeDate { get; set; }
    }
}
