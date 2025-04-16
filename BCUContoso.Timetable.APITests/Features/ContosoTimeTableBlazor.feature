Feature: Contosa Time Table Blazor UI

Background: Contosa Time table Blazor UI
Given Contosa Time Table Blazor is available

  Scenario: 3799-List Courses Page
  When user is navigated to courses page
  Then The page should display a table of courses with the following columns: ID, Name, Description, Code, Start Date, End Date
  And The table should be paginated, with 100 items per page
  And The page should include pagination controls to navigate between pages


  Scenario: 3800-Course Detail Page
  When user is navigated to a course page
  Then The page should display the following course details: ID, Name, Description, Code, Start Date, End Date
  And The page should include a list of enrolled students with the following columns: ID, Name, Email, Address, Phone Number, Enrollment Date


  Scenario: 3801-List Events Page
  When user is navigated to events page
  Then The page should display a table of events with the following columns: ID, Name, Description, Start Date, End Date, Location
  And The table should be paginated, with 100 items per page
  And The page should include pagination controls to navigate between pages
  And Each event should have a link to view its details


  Scenario: 3802-Event Detail Page
  When user is navigated to event details page
  Then The page should display the following event details: ID, Name, Description, Start Date, End Date, Location
  And The page should include the course details with the following properties: ID, Name, Description, Code, Start Date, End Date
  And The page should include a button to update the event location
  And The button should open a modal dialog to enter the new location


  Scenario: 3803-List Students Page
  
  Then The page should display a table of students with the following columns: ID, Name, Email, Address, Phone Number, Enrollment Date
  And The table should be paginated, with 100 items per page
  And The page should include pagination controls to navigate between pages
  And Each student should have a link to view their details

  Scenario: 3804-Student Detail Page
  Then The page should display the following student details: ID, Name, Email, Address, Phone Number, Enrollment Date
  And The page should include a list of enrolled courses with the following columns: ID, Name, Description, Code, Start Date, End Date
  And The page should include a button to update the student's name
