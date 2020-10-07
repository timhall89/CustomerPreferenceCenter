Customer Preference Centre
-

To run the console application do one of the following (NOTE: you must have dotnet core framework installed!)
- Open in Visual studio and run the CustomerPreferenceCenterConsole project
- Navigate to root folder in Command Line/Terminal and run `dotnet run --project CustomerPreferenceCenterConsole/CustomerPreferenceCenterConsole.csproj`

Please follow the application instructions in the console... these _should_ be enough for me not to need a detailed walkthrough in this README :)

here is a screenshot of what the application will look like:
<img src="/CustomerPreferenceCenter_Screenshot.png" alt="Screenshot"/>

### Solution overview
> #### CustomerPreferenceCenterLib
> This project contains the core functionality and logic of storing and processing Customer preferences.
> 
> I have allowed different _types_ of preference to be stored together by each preference class implement the same IPreference interface.

> #### CustomerPreferenceCenterLib.Test
> Tests for classes in CustomerPreferenceCenterLib project 

> ####  CustomerPreferenceCenterConsole
> This project contains the Console application with custom methods for writing and reading to and from the console.

### Technical Requirement

Customers are able to set their preferences for receiving marketing information. The following options are available:

- On a specified date of the month [1-28]

- On each specified day of the week [MON-SUN] (collection)

- Every day

- Never

  

Implement a system that accepts the choices of multiple customers as input. After receiving the input the system should produce a report of the upcoming 90 days. For each day that marketing material will be sent, the report should show which customers will be a recipient.

  

For example, Customer A chooses 'Every day'. Customer B chooses 'On the 10th of the month'. Customer C chooses ‘On Tuesday and Friday’. After providing this input the abridged output beginning in April would be:

|||
-|:-
|Sun 01-April-2018|A
|Mon 02-April-2018|A
|Tue 03-April-2018|A,C
|Wed 04-April-2018|A
|Thu 05-April-2018|A
|Fri 06-April-2018|A,C
|Sat 07-April-2018|A
|Sun 08-April-2018|A
|Mon 09-April-2018|A
|Tue 10-April-2018|A,B,C
|Wed 11-April-2018|A
|Thu 12-April-2018|A
|Fri 13-April-2018|A,C
|Sat 14-April-2018|A

The input/output format is yours to decide. You should aim to design a ‘turn-key’ solution but appropriate documentation is also welcome.