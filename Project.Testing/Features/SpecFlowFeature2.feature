Feature: SpecFlowFeature2
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
	Given I have entered 50 and 70 into the tool
	And I have entered 70 and 80 into the tool
	When I press combine
	Then the result should be 120 on the monitor
