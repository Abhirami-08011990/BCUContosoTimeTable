Feature: Course Pagination API

  Scenario: Valid page and sort option
    Given the API is available
    When I request page number 1 with sort option "name"
    Then the response status code should be 200
    And the response should contain course objects

  Scenario: Invalid page number
    Given the API is available
    When I request an invalid page number "-1"
    Then the response status code should be 400
