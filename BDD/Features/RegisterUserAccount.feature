# Test Data source can be improved using excel or csv files.
Feature: RegisterUserAccount
 
    Scenario: Verify that a user account is registered successfully when data is valid
        Given An Api /api/register
        And The following account details
            | Field | Value |
            | email | eve.holt@reqres.in |
            | password | pistol |
        When I perform post request
        Then I get status 200
        And An ID and token will be returned

    Scenario: Verify that a user account is not registered if email is not supplied
        Given An Api /api/register
        And The following account details
            | Field | Value |
            | password | pistol |
        When I perform post request
        Then I get status 400
        And An error message Missing email or username will be displayed

    Scenario: Verify that a user account is not registered if email and password is blank
        Given An Api /api/register
           And An empty request body
        When I perform post request
        Then I get status 400
        And An error message Missing email or username will be displayed

    Scenario: Verify that a user account is not registered if password  is not supplied
        Given An Api /api/register
            And The following account details
                | Field | Value |
                | email | eve.holt@reqres.in |
        When I perform post request
        Then I get status 400
        And An error message Missing password will be displayed

    Scenario: Verify that a user account is not registered if email is not a defined user
        Given An Api /api/register
            And The following account details
                | Field | Value |
                | email | eve.holt@test.com |
                | password | pistol |
        When I perform post request
        Then I get status 400
        And An error message Note: Only defined users succeed registration will be displayed