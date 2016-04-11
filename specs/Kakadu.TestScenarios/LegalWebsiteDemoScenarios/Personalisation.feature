Feature: Personalisation
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@NeedImplementation
Scenario: xDB Panel_UC1_no information for visitor
	Given User has opened Legal website
	And User has opened xDB info panel
	When User selects Onsite Behavior section
	Then <Profiling> contains following values
	| field value                    |
	| You have not been profiled yet |
	And <Triggered goals> contains following values
	| field value                        |
	| You have triggered no goals so far |
	And <Outcomes> contains following values
	| field value                        |
	| You have reached no outcomes       |

@NeedImplementation
Scenario: xDB Panel_UC2_associated persona for Corporate Finance page
	Given User has opened Legal website
	And User has opened Corporate Finance page
	And User has opened xDB info panel
	When User selects Onsite Behavior section
	Then <Profiling> contains following values
	| field values          |
	| Legal Persona         |
	| Susan the CEO         |
	| Eric the Entrepreneur |
	| Margaret the Mother   |
    | Lucas the Lawyer      |
	And <Triggered goals> contains following values
	| field value                        |
	| You have triggered no goals so far |
	And <Outcomes> contains following values
	| field value                        |
	| You have reached no outcomes       |
	And on Home page <Profiling> contains following values
	| field values          |
	| Legal Persona         |
	| Susan the CEO         |
	| Eric the Entrepreneur |
	| Margaret the Mother   |
    | Lucas the Lawyer      |
	And <Triggered goals> contains following values
	| field value                        |
	| You have triggered no goals so far |
	And <Outcomes> contains following values
	| field value                        |
	| You have reached no outcomes       |

@NeedImplementation 		
Scenario: xDB Panel_UC3_associated persona for Trust, Estate, and Tax Law page
	Given User has opened Legal website
	And User has opened Trust, Estate, and Tax Law page
	And User has opened xDB info panel
	When User selects Onsite Behavior section
	Then <Profiling> contains following values
	| field name            | 
	| Legal Persona         |
	| Margaret the Mother   |
	| Eric the Entrepreneur |
	| Susan the CEO         |
    | Lucas the Lawyer      |
	And <Triggered goals> contains following values
	| field value                        |
	| You have triggered no goals so far |
	And <Outcomes> contains following values
	| field value                        |
	| You have reached no outcomes       |
	And on Home page <Profiling> contains following values
	| field name            | 
	| Legal Persona         |
	| Margaret the Mother   |
	| Eric the Entrepreneur |
	| Susan the CEO         |
    | Lucas the Lawyer      |
	And <Triggered goals> contains following values
	| field value                        |
	| You have triggered no goals so far |
	And <Outcomes> contains following values
	| field value                        |
	| You have reached no outcomes       |
