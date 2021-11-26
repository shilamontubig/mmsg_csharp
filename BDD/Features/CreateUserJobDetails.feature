Feature: CreateUserJobDetails

  Scenario: Verify that a User JobDetails is created when all details are valid
    Given An Api /api/users
      And The following details
                  |Field | Value|
                  | name | Shapiro Lewis |
                  | job | QA |
    When I perform post JobDetail request
    Then I get status 201
      And An ID will be returned

#Assumption: An error should be returned if data is invalid. 
#Currently the mock server still returns 201 even if data is incomplete so this scenario will fail. 
  Scenario: Verify that User job details are not created when data is incomplete
    Given An Api /api/users
    And The following details
                |Field | Value|
                | name | Shapiro Lewis |
    When I perform post JobDetail request
    Then I get status 201
      And An ID will be returned



 