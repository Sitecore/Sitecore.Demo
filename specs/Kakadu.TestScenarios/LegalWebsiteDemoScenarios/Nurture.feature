Feature: Nurture

	As a marketer
    I want to see a site visitor progress
	though my site directed to the outcome I want

@OnlyManual
Scenario: Nurture_UC1_Open Webinar Nurture plan in the Marketing Control panel
	Given User logged to the Sitecore as Emma
	And Marketing Control Panel is launched
	When User expands Engagement Plans section
	And User expands Legal folder
	And User selects the Webinar Nurture plan
	Then Webinar Nurture contains following sections
	| Section name | State       | Title                |
	| Search       | Registered? | Requested More Info  |
	| Register     | Downloaded  | Registered ForWebinar|
	| Engaged      | <empty>     | Downloaded Whitepaper|


@OnlyManual
Scenario: Nurture_UC2_Open Webinar Nurture plan in Supervisor mode
	Given User logged to the Sitecore as Emma
	And Marketing Control Panel is launched
	And Engagement Plans section is opened
	And Legal engagement plan is expanded
	When User selects the Webinar Nurture plan
	And User selects Supervise button
	Then Then Supervisor window has opened 
    And System shows 0% for each state 


@NeedImplementation
Scenario: Nurture_UC3_Open Taxation Webinar Information form
	Given Legal website homepage is opened in private browsing session
	When Actor clicks <Find Out More> link
	Then <Taxation Webinar Information> form with following fields is opened:
	| Field      |
	| Email      |
	| First Name |
	| Last Name  |


@NeedImplementation
Scenario: Nurture_UC4_Open Taxation Webinar Information form About Us page
	Given Legal website homepage is opened in private browsing session
	When Actor navigates to the /About-Us page
	And Actor clicks <Find Out More> link
	Then <Taxation Webinar Information> form with following fields is opened:
	| Field      |
	| Email      |
	| First Name |
	| Last Name  |


@NeedImplementation
Scenario: Nurture_UC5_Submit Taxation Webinar Information form
	Given Legal website homepage is opened in private browsing session
	When Actor clicks <Find Out More> link
	And Actor enters following data in to the <Taxation Webinar Information> form fields
	| Email              | First Name  | Last Name      |
	| ace5@sitecore.net  | Anna        | Chervonchenko  |      
	And Actor clicks <Send Me Information> button
	Then Landing-Pages/Taxation-Webinar/Thank-You page is opened
    And <Thank you> title presents
	And Following registration text presents:
	|Text																																	   				 |
	| Our servers are processing your request now. As soon as your request has been processed, we will send a confirmation email to the address you supplied.|

		
@NeedImplementation
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
	And Engagement plan sate equals to <Requested More Info>


@NeedImplementation
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


@NeedImplementation
Scenario: Nurture_UC8_Check Onsite Behavior section
	Given Legal website homepage is opened in private browsing session
	When Actor clicks <Find Out More> link
	And Actor enters following data in to the form fields
	| Email              | First Name  | Last Name      |
	| ace8@sitecore.net  | Anna        | Chervonchenko  |      
	And Actor clicks <Send Me Information> button
	And Actor expands xDB panel
	And Actor expands Onsite Behavior section
	Then following information is present in the section
	| Legal Persona    | Triggered goals         | Outcomes             |
	| Lucas the Lawyer | More Info Legal Webinar | Contact Acquisition  |


@NeedImplementation
Scenario: Nurture_UC9_Check Carousel personalization
	Given Legal website homepage is opened in private browsing session
	And Actor clicked <Find Out More> link
	And Actor entered following data in to the form fields
	| Email              | First Name  | Last Name      |
	| ace9@sitecore.net  | Anna        | Chervonchenko  |      
	And Actor clicked <Send Me Information> button
	When Actor navigates to Home page
	Then <Register Now> link available in the Carousel


@NeedImplementation
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
	 

@NeedImplementation
Scenario: Nurture_UC11_Register now
	Given Legal website is opened on the /Landing-Pages/Taxation-Webinar/Taxation-Webinar-Register page
	When Actor enters followind data into form fields
	| Email               | First Name  | Last Name      | Month Preference  |
	| ace11@sitecore.net  | Anna        | Chervonchenko  | January           |
	And Actor clicks <Register Now> button
	Then /Landing-Pages/Taxation-Webinar/Thank-You page is opened


@NeedImplementation
Scenario: Nurture_UC12_Trigger outcomes on registration
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
	And <Thank you> title presents
	And Following registration text presents:
	| Text                                                                                                                                                    |
	| Our servers are processing your request now. As soon as your request has been processed, we will send a confirmation email to the address you supplied. |


@NeedImplementation
Scenario: Nurture_UC13_Download whitepaper
	Given <Taxation Webinar Information> form is submitted
	And <Taxation Webinar Registration> form is submitted
	And  Legal website homepage is opened in private browsing session
	When Actor clicks <Download Now> link
	And Actor saves pdf file on file sysytem
	And Actor expands xDB panel
	And Actor clicks <Refresh> button on teh left side of the xDB panel
	And Actor expands Onsite Behavior section
	Then following information is present in the section
    | Triggered goals                    | Value |
	| Download White Paper Legal Webinar | 20    | 


@NeedImplementation
Scenario: Nurture_UC14_Alternate demo path. Email mock-up page. Check personalized info page
	Given Legal website is opened on the /Legal/Email page
	When Actor clicks <Register now> link
	Then page URL contains sc_camp=356A7E5445E14860AFBBF922E8A3018F
    And <Taxation Webinar Register> form with following fields is opened
	| Field				|
	| Email				|
	| First Name		|
	| Last Name			|
	| Month Preference	|
	And <Register Now> button presents on the page


@NeedImplementation
Scenario: Nurture_UC15_Alternate demo path. Email mock-up page. Verify xDB panel
	Given Legal website is opened on the /Legal/Email page
	When Actor clicks <Register now> link
	And Actor expands xDB panel
	And Actor expands Referral section
	Then following information is present in the Campaigns section
    | Field values                           |
    | Active                                 |
    | Email Legal Webinar                    |
    | Online/Email campaigns/Email marketing |


@NeedImplementation
Scenario: Nurture_UC16_Alternate demo path. Facebook campaign. Check personalized info page
	Given Facebook website is opened on the https://www.facebook.com/ridleysc/ page
	When Actor clicks link with sc_camp=23A9161A0CA847ACB718D100B65A1328
    Then <Taxation Webinar Information> form with following fields is opened
	| Field				|
	| Email				|
	| First Name		|
	| Last Name			|
	And <Send Me Information> button presents on the page
	And Title contains <Taxation Webinar Information>


@NeedImplementation
Scenario: Nurture_UC17_Alternate demo path. Facebook campaign. Verify xDB panel
	Given Facebook website is opened on the https://www.facebook.com/ridleysc/ page
	When Actor clicks link with sc_camp=23A9161A0CA847ACB718D100B65A1328
	And Actor expands xDB panel
	And Actor expands Referral section
	Then following information is present in the Campaigns section
    | Field values                                      |
    | Active                                            |
    | Facebook Legal Webinar                            |
    | Online/Social community/Facebook social community |


@NeedImplementation
Scenario: Nurture_UC18_Alternate demo path. Twitter campaign. Check personalized info page
	Given Twitter website is opened on the https://twitter.com/DSTChase page
	When Actor clicks link with sc_camp=63FEB1E773A0420B9CED034CF07F7D78
    Then <Taxation Webinar Information> form with following fields is opened
	| Field				|
	| Email				|
	| First Name		|
	| Last Name			|
	And <Send Me Information> button presents on the page
	And image with alt="twitter" presents on the page


@NeedImplementation
Scenario: Nurture_UC19_Alternate demo path. Twitter campaign. Verify xDB panel
	Given Twitter website is opened on the https://twitter.com/DSTChase page
	When Actor clicks link with sc_camp=63FEB1E773A0420B9CED034CF07F7D78
	And Actor expands xDB panel
	And Actor expands Referral section
	Then following information is present in the Campaigns section
    | Field values                                     |
    | Active                                           |
    | Twitter Legal Webinar                            |
    | Online/Social community/Twitter social community |


@NeedImplementation
Scenario: Nurture_UC20_Alternate demo path. Mock-up of a paid search page. Check personalized info page
	Given Legal website is opened on the Legal/Search page
	When Actor clicks link with sc_camp=D0D5445D-C856-4FEA-9133-30E69A341D5C
    Then <Taxation Webinar Information> form with following fields is opened
	| Field				|
	| Email				|
	| First Name		|
	| Last Name			|
	And <Send Me Information> button presents on the page
	And Title contains <Taxation Webinar Information>


@NeedImplementation
Scenario: Nurture_UC21_Alternate demo path. Mock-up of a paid search page. Verify xDB panel
	Given Legal website is opened on the Legal/Search page
	When Actor clicks link with sc_camp=D0D5445D-C856-4FEA-9133-30E69A341D5C
	And Actor expands xDB panel
	And Actor expands Refferal section
	Then following information is present in the Campaigns section
    | Field values                  |
    | Active                        |
    | Search Legal Webinar          |
    | Online/Paid search/Google ads | 