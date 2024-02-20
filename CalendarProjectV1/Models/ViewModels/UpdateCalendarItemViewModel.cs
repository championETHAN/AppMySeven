using CalendarProjectV1.Models.Domain;

namespace CalendarProjectV1.Models.ViewModels
{
    public class UpdateCalendarItemViewModel
    {
        public Guid Id { get; set; }
        public DateTime AssignedDate { get; set; }

        private string _nameOfAssignedDate;
        public string NameOfAssignedDate
        {
            get { return _nameOfAssignedDate; }
            set => _nameOfAssignedDate = AssignedDate.ToString("dddd"); 
        }
        public string Title { get; set; }
        public string Location { get; set; }
        public PriorityEnum AssignedPriority { get; set; }
        public string Note { get; set; }
    }
}
