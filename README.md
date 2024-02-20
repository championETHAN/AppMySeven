# MySeven Implemented Features:
Social Media Calendar / LifeStyle App

# All basic CRUD Operations
    --->Create == Add(calendarItems)
                  ---->Id = Guid: Used to create unique Id values for each new calendarItem
                  ---->AssignedDate = DateTime
                  ---->NameOfAssignedDate = _nameOfAssignedDate: (To save the written values of name-of-day-of-week for later use)
                  ---->String = Title
                  ---->String = Location: (As of now, not fully implemented; Will be parsed out as "LocationInfo" later for integration with "A Mapping Service")
                  ---->Enum = PriorityEnum == AssignedPriority: Used to set a calendarItem's Priority; Not fully implemented and will be expanded later, but is currently working.
                  ---->String = Note: Using an external library called "Froala" the Note section under every calendarItem is now a rich text editor
    --->Read  = "view"
    --->Update = located under "view"
    --->Delete = located under "view"
# SQL Database connection
    -->Connection name: DESKTOP-GMJO2I4\SQLEXPRESS
    -->Database name: CalendarDB
    -->Table name: CalendarItems
    -->DatabaseContext: calendarProjectDbContext
# Searching DbTable: CalendarItems
    -->On the Index Page of the ItemsController (aka "Read")
# Sorting DbTable: CalendarItems
    -->On the Index Page of the ItemsController (aka "Read")
    -->By Title == OrderByDescending
    -->By Date == OrderByDescending 
