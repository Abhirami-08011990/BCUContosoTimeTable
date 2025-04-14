Feature: Course Pagination API

  Scenario: Valid page and sort option
    Given the API is available
    When I request page number 1 with sort option "NameAscending"
    Then the response status code should be 200
    And the response should contain a list of courses
    And each course should have id, name, description, code, startDate, and endDate

  Scenario: Update event name
    Given the API is available
    When I update the name of event with ID 1 to "Manchester"
    Then the response status code should be 200

  Scenario: Get course by ID
    Given the API is available
    When I request the course with ID 1
    Then the response status code should be 200
    And the course should contain id, name, description, code, startDate, and endDate

  Scenario: Get paginated events with sort options
    Given the API is available
    When I request events page number 1 with sort option "DateDescending"
    Then the response status code should be 200
    And the response should contain a list of events
    And each event should have id, name, location, startDate, and endDate

  Scenario: Get event by ID
    Given the API is available
    When I request the event with ID 1
    Then the response status code should be 200
    And the event should have id, name, location, startDate, and endDate

  Scenario: Get paginated students with sort options
    Given the API is available
    When I request students page number 1 with sort option "NameAscending"
    Then the response status code should be 200
    And the response should contain a list of students
    And each student should have id, name, email, and enrolmentDate

  Scenario: Update event location
    Given the API is available
    When I update the location of event with ID 1 to "London"
    Then the response status code should be 200

  Scenario: Update student name
    Given the API is available
    When I update the name of student with ID 1 to "John Doe"
    Then the response status code should be 200


