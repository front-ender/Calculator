# Sample SOLID code

Extend an older Calculator API. 

Created a PR for each user story.

User Stories

### 1 Extend Logging System
Currently we only log to SQL. Now we also wants logs to a file and written to console.
Please implement this functionality.

### 2 Division functionality
Customers require a API that allows for division, extend our functionality to allow for that usage

### 3 Add more than two numbers 
Customers need a API to add up to five numbers, extend our functionality to allow for that usage

### 4 Temperature near your home town
We want to extend out API functionality so the customer to be able to see temperature near their home town using data from https://www.weatherapi.com/ 
Implement an API that takes city at input, fetches data from https://www.weatherapi.com/ and then returns the data to the user.
We use System.Net.Http.HttpClient for http clien communication.

## Considering factors
Code is maintable, understandable, flexible and testable.
Focus on SOLID principles and consider how the APIs can be made more secure - eg via http header security tokens, https etc.

