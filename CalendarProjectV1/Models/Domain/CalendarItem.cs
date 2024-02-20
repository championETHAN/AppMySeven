using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CalendarProjectV1.Models.Domain
{
    public class CalendarItem
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
