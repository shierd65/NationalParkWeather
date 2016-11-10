Feature: NationalParkSurvey
	In order to see the details of a park
	When I click on a photo from the park list page
	Then I should see the details for that park

@mytag
Scenario: ClickPictureGetDetailPage
	Given I am on the park list page
	When I click on a park picture
	Then I should see the park detail page
