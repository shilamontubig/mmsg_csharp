Feature: DeleteUser

#Additional Database validation can be implemented here
Scenario: Verify that a User is Deleted Successfully
    Given An Api /api/users/3
    When I perform delete request
    Then  I get status 204
        And I get an empty response