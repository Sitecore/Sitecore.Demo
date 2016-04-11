Feature: Nurture

	As a marketer
    I want to see a site visitor progress
	though my site directed to the outcome I want

@NeedReview
Scenario: Nurture_UC1_Open Webinar Nurture plan in the Marketing Control panel
	Given User logged to the Sitecore 
	And Marketing Control Panel is launched
	When User expands Engagement Plans section
	And User expands Legal folder
	And User selects the Webinar Nurture plan
	Then This shows how a visitor will progress from requesting information to being offered access to the legal portal


@NeedReview
Scenario: Nurture_UC2_Open Webinar Nurture plan in Supersisor mode
	Given User logged to the Sitecore
	And Marketing Control Panel is launched
	And Engagement Plans section is opened
	And Legal engagement plan is expanded
	When User selects the Webinar Nurture plan
	And User selects Supervise button
	Then this shows which site visitors are in which part of the plan


@NeedReview
Scenario: Nurture_UC3_Open Taxation Webinar Information form
	Given Legal website homepage is opened in private browsing session
	When Actor clicks <Find Out More> link
	Then <Taxation Webinar Information> form with following fields is opened:
	| Field      |
	| Email      |
	| First Name |
	| Last Name  |


@NeedReview
Scenario: Nurture_UC4_Open Taxation Webinar Information form About Us page
	Given Legal website homepage is opened in private browsing session
	When Actor navigates to the /About-Us page
	And Actor clicks <Find Out More> link
	Then <Taxation Webinar Information> form with following fields is opened:
	| Field      |
	| Email      |
	| First Name |
	| Last Name  |


@NeedReview
Scenario: Nurture_UC5_Submit Taxation Webinar Information form
	Given Legal website homepage is opened in private browsing session
	When Actor clicks <Find Out More> link
	And Actor enters following data in to the <Taxation Webinar Information> form fields
	| Email              | First Name  | Last Name      |
	| ace5@sitecore.net  | Anna        | Chervonchenko  |      
	And Actor clicks <Send Me Information> button
	Then Landing-Pages/Taxation-Webinar/Thank-You page is opened
	
	
@NeedReview
Scenario: Nurture_UC6_Check Engagement plans section
	Given Legal website homepage is opened in private browsing session
	When Actor clicks <Find Out More> link
	And Actor enters following data in to the form fields
	| Email              | First Name  | Last Name      |
	| ace6@sitecore.net  | Anna        | Chervonchenko  |      
	And Actor clicks <Send Me Information> button
	And Actor expands xDB panel
	And Actor expands Engagement section
	Then Engagement plans section contains <Webinar Nurture>


@NeedReview
Scenario: Nurture_UC7_Check Personal Information section
	Given Legal website homepage is opened in private browsing session
	When Actor clicks <Find Out More> link
	And Actor enters following data in to the form fields
	| Email              | First Name  | Last Name     |
	| ace7@sitecore.net  | Anna        | Chervonchenko |      
	And Actor clicks <Send Me Information> button
	And Actor expands xDB panel
	And Actor expands Personal Information section
	Then Personal Information section contains followind data
	|Email (Preferred) | Identification                    |                   
	| ace7@sitecore.net|extranet\ace7_at_sitecore_dot_net  |


@NeedReview
Scenario: Nurture_UC8_Check Onsite Behavior section
	Given Legal website homepage is opened in private browsing session
	When Actor clicks <Find Out More> link
	And Actor enters following data in to the form fields
	| Email              | First Name  | Last Name      |
	| ace8@sitecore.net  | Anna        | Chervonchenko  |      
	And Actor clicks <Send Me Information button>
	And Actor expands xDB panel
	And Actor expands Onsite Behavior section
	Then following information is present in the section
	| Legal Persona    | Triggered goals         | Outcomes             |
	| Lucas the Lawyer | More Info Legal Webinar | Contact Acquisition  |


@NeedReview
Scenario: Nurture_UC9_Check Carousel personalization
	Given Legal website homepage is opened in private browsing session
	And Actor clicked <Find Out More> link
	And Actor entered following data in to the form fields
	| Email              | First Name  | Last Name      |
	| ace9@sitecore.net  | Anna        | Chervonchenko  |      
	And Actor clicked <Send Me Information> button
	When Actor navigates to Home page
	Then <Register Now> link available in the Carousel


@NeedReview
Scenario: Nurture_UC10_Check registration form pre-population
	Given Legal website homepage is opened in private browsing session
	And Actor clicked <Find Out More> link
	And Actor entered following data in to the form fields
	| Email               | First Name  | Last Name      |
	| ace10@sitecore.net  | Anna        | Chervonchenko  |      
	And Actor clicked <Send Me Information button>
	When Actor navigates to Home page
	And Actor clicks <Register Now> link
	Then form fields contain following data 
	| Email               | First Name  | Last Name      | Month Preference  |
	| ace10@sitecore.net  | Anna        | Chervonchenko  | January           |
	 

@NeedReview
Scenario: Nurture_UC11_
	Given Legal website is opened on the /Landing-Pages/Taxation-Webinar/Taxation-Webinar-Register page
	When Actor enters followind data into form fields
	| Email               | First Name  | Last Name      | Month Preference  |
	| ace11@sitecore.net  | Anna        | Chervonchenko  | January           |
	And Actor clicks <Register Now> button
	Then /Landing-Pages/Taxation-Webinar/Thank-You page is opened


@NeedReview
Scenario: Nurture_UC12_
	Given Legal website is opened on the /Landing-Pages/Taxation-Webinar/Taxation-Webinar-Register page
	When Actor enters followind data into form fields
	| Email               | First Name  | Last Name      | Month Preference  |
	| ace12@sitecore.net  | Anna        | Chervonchenko  | January           |
	And Actor clicks <Register Now> button
	And Actor expands xDB panel
	And Actor expands Onsite Behavior section
	Then following information is present in the section
    | Triggered goals          | Outcomes             |
	| Registered Legal Webinar | Marketing Lead       | 

@NeedReview
Scenario: Nurture_UC13_
Given Legal website is opened on the /Landing-Pages/Taxation-Webinar/Taxation-Webinar-Register page
	When Actor enters followind data into form fields
	| Email               | First Name  | Last Name      | Month Preference  |
	| ace12@sitecore.net  | Anna        | Chervonchenko  | January           |
	And Actor clicks <Register Now> button
	And Actor expands xDB panel
	And Actor expands Onsite Behavior section
	Then following information is present in the section
    | Triggered goals          | Outcomes             |
	| Registered Legal Webinar | Marketing Lead       | 