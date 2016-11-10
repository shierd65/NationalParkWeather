Feature: TakeSurvey
	In order to see the results of the park survey
	When I enter my information
	Then I should see the survey results page

@mytag
Scenario: TakeSurvey
	Given I am on the Survey Input Page
	When I enter valid information and submit the survey
	Then I should see the survey result page
