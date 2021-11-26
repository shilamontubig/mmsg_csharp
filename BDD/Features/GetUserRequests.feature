# Improvements: Additional verification using database data can also be used. 
# Test Data source can be improved using excel or csv files.
Feature: GetUserRequests

    Scenario: Get All Users
        Given An Api /api/users
        When I perform a Get request
        Then I get status 200
        And The following data are displayed
                |Field | Value|
                | page | 1 |
                | per_page | 6 |
                | total_pages | 2 |
                | total | 12 |
        And Number of user data is equal to 6

    Scenario: Get All Users with filters
        Given An Api /api/users
        And I add query params using the following
                |Field | Value|
                | page | 2 |
                | per_page | 4 |
        When I perform a Get request
        Then I get status 200
        And The following data are displayed
                |Field | Value|
                | page | 2 |
                | per_page | 4 |
                | total | 12 |
                | total_pages | 3 |
        And Number of user data is equal to 4

    Scenario: Verify Single User is Displayed
        Given An Api /api/users/2
        When I perform a Get request
        Then I get status 200
        And The correct user data is displayed
            |Field | Value|
            | id | 2 |
            | email | janet.weaver@reqres.in |
            | first_name | Janet |
            | last_name | Weaver |
            | avatar | https://reqres.in/img/faces/2-image.jpg |

    Scenario: Verify Single User is not found
        Given An Api /api/users/23
        When I perform a Get request
        Then I get status 404
        And I get an empty response

    Scenario: Verify Single Resource is not found
        Given An Api /api/unknown/23
        When I perform a Get request
        Then I get status 404
        And I get an empty response