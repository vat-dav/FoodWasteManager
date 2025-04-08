namespace FoodWasteManager.Models
{
    public class Holiday
    {
        public int HolidayId { get; set; }
        public string HolidayName { get; set; }
        public DateOnly HolidayDate { get; set; }

        public ICollection<OrgHour> OrgHours { get; set; }  
    }

}
