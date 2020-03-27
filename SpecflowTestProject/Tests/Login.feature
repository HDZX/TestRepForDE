Feature: Login
	In order to login in NewBookModels
	As a client of NewBookModels
	I want to be logged in NewBookModels

@mytag
Scenario: It is possible to login in NewBookModels with valid data
	Given Client is created
	And Sign in page is opened
	When I input email of created client in email field
	And I input password of created client in email field
	And I click Log in button
	Then I successfully logged in NewBookModels as created client

Scenario: It is possible to change client's avatar through ui
	Given Client is created
	And Successfully logged into NewBookModels through Api
	And Profile page is opened
	When I click on pencil button
	And I upload client's photo
	And I input company name 'Tratata' in company name field
	And I input company url 'https://newbookmodels.com/account-settings/profile/edit' in company url field
	And I input 'asdasdasdsad' in description field
	And I click save changes button
	Then Client's avatar is successfully changed