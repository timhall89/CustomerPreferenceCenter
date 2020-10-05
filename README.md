
## Technical Exercise
### Implement a Customer Preference Centre
Customers are able to set their preferences for receiving marketing information. The following options are available:
- On a specified date of the month [1-28]
- On each specified day of the week [MON-SUN] (collection)
- Every day 
- Never

Implement a system that accepts the choices of multiple customers as input. After receiving the input the system should produce a report of the upcoming 90 days. For each day that marketing material will be sent, the report should show which customers will be a recipient.

For example, Customer A chooses 'Every day'. Customer B chooses 'On the 10th of the month'. Customer C chooses ‘On Tuesday and Friday’. After providing this input the abridged output beginning in April would be:
|||
|----------|:-------------:|
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