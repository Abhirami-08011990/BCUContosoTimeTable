Feature: Contosa Time Table API

Background: Contosa Time table API
 Given Contosa Time Table API is available

  Scenario: 3790-GET CourseSort Options   
    When I request courses page number 1 with sort option "NameAscending"
    Then the response status code should be 200
    And the response should contain a list of courses
    And each course should have id, name, startDate, and endDate

  Scenario: 3792-PUT Update New Course Name
    
    When I update the name of event with ID 1 to "Manchester"
    Then the response status code should be 200

  Scenario: 3791 -GET Course Id
    
    When I request the course with ID 1
    Then the response status code should be 200
    And the course should contain id, name, description, code, startDate, and endDate

  Scenario: 3793-GET Event Sort Options
    
    When I request events page number 1 with sort option "NameDescending"
    Then the response status code should be 200
    And each event should have id, name, startDate, and endDate

  Scenario: 3794-GET Event ID
    
    When I request the event with ID 91
    Then the response status code should be 200
    And each course should have id, name, startDate, and endDate

  Scenario: 3796-GET Student Sort Options
    
    When I request students page number 1 with sort option "NameAscending"
    Then the response status code should be 200
    And the response should contain a list of students
    And each student should have id, name, email, and enrolmentDate

  Scenario: 3797-GET Student ID
    
    When I update the location of event with ID 91 to "London"
    Then the response status code should be 200

  Scenario: 3798-PUT Update New Student Name
    
    When I update the name of student with ID 1 to "John Doe"
    Then the response status code should be 200


