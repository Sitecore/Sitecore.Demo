@NeedImplementation 		
Scenario: xDB Panel_UC1_no information for visitor
	Given User has opened Legal website
	And User has opened xDB info panel
	When User selects Onsite Behavior section
	Then Onsite Behavior section does not have any information

@NeedImplementation 		


Scenario: xDB Panel_UC2_associated persona for Corporate Finance page
	Given User opened Legal website
	And User has opened Corporate Finance page
	And User has opened xDB info panel
	When User selects Onsite Behavior section
	Then Onsite Behavior section contains associated persona information
	And carousel is personalized to match associated  persona information on Home page also
	

 		
@NeedImplementation
Scenario: xDB Panel_UC3_associated persona for Trust, Estate, and Tax Law page
	Given User opened Legal website
	And User has opened Trust, Estate, and Tax Law page
	And User has opened xDB info panel
	When User selects Onsite Behavior section
	Then Onsite Behavior section contains associated persona information
	And carousel is personalized to match associated  persona information on Home page also
