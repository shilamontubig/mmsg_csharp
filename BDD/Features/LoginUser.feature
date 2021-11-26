# Due to limitation of the mock server, other scenarios
# like incorrect email or password is not included here.

Feature: LoginUser

    Scenario: Verify that user can login successfully when using Valid data
        Given An Api /api/login
            And The following account details
                | Field | Value |
                | email | eve.holt@reqres.in |
                | password | pistol |
        When I perform post request
        Then I get status 200
        And A token will be returned

    Scenario: Verify that an error is displayed when email is not present
        Given An Api /api/login
        And The following account details
            | Field | Value |
            | password | pistol |
        When I perform post request
        Then I get status 400
        And An error message Missing email or username will be displayed

    Scenario: Verify that an error is displayed when email and password is not present
        Given An Api /api/login
           And An empty request body
        When I perform post request
        Then I get status 400
        And An error message Missing email or username will be displayed

    Scenario: Verify that an error is displayed when password is not present
        Given An Api /api/login
            And The following account details
                | Field | Value |
                | email | eve.holt@reqres.in |
        When I perform post request
        Then I get status 400
        And An error message Missing password will be displayed