@UI
Feature: Personalisation
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Ready
Scenario: xDB Panel_UC1_no information for visitor
	Given User has opened Legal website
	And Actor selects Open visit details panel slidebar
	When Actor expands Onsite Behavior header on xDB panel
	Then Profiling contains following values
	| field value                        |
	| You have not been profiled yet     |
	And Triggered goals contains following values
	| field value                        |
	| You have triggered no goals so far |
	And Outcomes contains following values
	| field value                        |
	| You have reached no outcomes       |
	
@Ready
Scenario: xDB Panel_UC2_associated persona for Corporate Finance page
	Given User has opened Legal website
	And User has opened Corporate Finance page
	And Actor selects Open visit details panel slidebar
	When Actor expands Onsite Behavior header on xDB panel
	Then Following information is present in the section
    | Legal Persona         |
    | Susan the CEO         |
	| Eric the Entrepreneur |
	| Margaret the Mother   |
    | Lucas the Lawyer      |
    And Triggered goals contains following values 
	|field value                        |
	|You have triggered no goals so far |
	And Outcomes contains following values
	|field value                        |
	|You have reached no outcomes       |

@Ready
	Scenario: xDB Panel_UC3_associated persona for Home page
	Given User has opened Legal website
	And User has opened Corporate Finance page
	When User has opened Legal website
	And Actor selects Open visit details panel slidebar 
	And Actor expands Onsite Behavior header on xDB panel
	Then Following information is present in the section
    | Legal Persona         |
    | Susan the CEO         |
	| Eric the Entrepreneur |
	| Margaret the Mother   |
    | Lucas the Lawyer      |
And Triggered goals contains following values
	| field value                        |
	| You have triggered no goals so far |
	And Outcomes contains following values
	| field value                        |
	| You have reached no outcomes       |

@Ready 		
Scenario: xDB Panel_UC4_associated persona for Trust, Estate, and Tax Law page
	Given User has opened Legal website
	And User has opened Trust, Estate, and Tax Law page
	And Actor selects Open visit details panel slidebar
	When Actor expands Onsite Behavior header on xDB panel
	Then Following information is present in the section
	| Legal Persona         |
	| Margaret the Mother   |
	| Eric the Entrepreneur |
	| Susan the CEO         |
    | Lucas the Lawyer      |
	And Triggered goals contains following values
	| field value                        |
	| You have triggered no goals so far |
	And Outcomes contains following values
	| field value                        |
	| You have reached no outcomes       |


@Ready 		
Scenario: xDB Panel_UC5_associated persona for Home page
	Given User has opened Legal website
	And User has opened Trust, Estate, and Tax Law page
	When User has opened Legal website
	And Actor selects Open visit details panel slidebar 
	And Actor expands Onsite Behavior header on xDB panel
	Then Following information is present in the section
	| Legal Persona         |
	| Margaret the Mother   |
	| Eric the Entrepreneur |
	| Susan the CEO         |
    | Lucas the Lawyer      |
	And Triggered goals contains following values
	| field value                        |
	| You have triggered no goals so far |
	And Outcomes contains following values
	| field value                        |
	| You have reached no outcomes       |
