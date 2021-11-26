# Environment Setup
During development to provide environment variables to the solution create a file named env.json at the root of the project folder. For example:

**{
 "BASE_URL":"http://localhost:8080"
}**


## Answers to the questions in the case study document 

**Question 1**: Following are the possible webservices and test cases that I have identified based on the design document: 
 Please note that the response codes are based on my assumptions and may still be changed depending on the API contract. 

 1. Registration (has a POST webservice and UI component)
	 
	 
- Verify that when all mandatory data are provided in the api POST request body and they have the correct format then the response should be 201. 
- If the response is 201, the UI page should also display a Successful message. 
- Assuming that the registration data is saved in the database, we should verify that data we sent via webservice are stored in the database table correctly.
- Verify that  when incomplete data are provided in the request body then the response should be 400. An error message should also be returned.
- Proper data error validations should also be available in the UI. ie. verify for the completeness and formats of data
- Verify that incorrect data formats also receives status code 400 and returns an error message.
- If incorrect url path is used to Post the request, error 404 should be received. 

 2. Login (has a POST webservice and UI component)

- Proper data error validations should also be available in the UI. ie. verify for the completeness and incorrect login validation
- Verify that either incorrect username/email or password produces a 401 status code along with an error message when a POST Login request is performed.
- Verify that when correct login data is sent via API, the response code 200 is received. 
- Verify that incomplete login data produces 400 status code (via api).
- If incorrect url path is used to Post the login request, error 404 should be received. 

 3. Movie  (has a GET webservice and UI component)

- Assumption - the webservice accepts different query parameters such as movie title, genre,  cinema number and screening date and time. 
- The api service returns a list of movie data and a response of 200 based on the query parameters supplied.
- Assuming that there is a database with movie information, we should validate the movie Api response against the database data.
- Verify that all the data from the Api response is displayed in the UI correctly.  

 
 4. Seat Availability (has a POST webservice and UI component)

- Assumption: Seat webservice accepts movie id, cinema number and screening date and time. I have assumed that this is a POST request since the seat information needs to be secure.
- When all mandatory data are provided in the api call, the request should return a 200 response and a list of seats with seat number, seat id and status (if taken or not).
- if incomplete data is provided, a 400 response should be returned.
- if incorrect data is provided such as wrong date, cinema number and title, an empty response should be returned along with response 200. 
- If incorrect url path is used to Post the request, error 404 should be received.
- Response data should also be verified in the database if necessary. 
- The data based on the webservice responses should also be verified in the UI. 

 5. Update Seat Status Request (Update Request) - accepts seat_id, status and order number (assuming that each seat is matched with an order id once it is taken/booked). 

- 201 response is received when all required data are supplied. 
- If incorrect url path is used to send the request, error 404 should be received.
- if incomplete data is provided, a 400 response should be returned.

 6. Validate TED Card webservice (has a GET webservice and UI component) 

- The Api accepts the TED Card Number
- Returns 200 when TED Card is found and returns status of the card ie. active or not and expiration date. 
- if no TED Card no. is supplied error 400 should be returned. 
- If incorrect url path is used to send the request, error 404 should be received.
- The data based on the webservice responses should also be verified in the UI.

 7. Get Applicable Promo Webservice (POST Request) - Assumption: the request accepts has_valid_ted_card (boolean), screening date and time, number of tickets bought. 

- Returns 200 if all data are supplied and sends back promo_id, discount, number of free tickets and promo expiration date. 
- if no applicable promo is found an empty response body and status 200 should be returned.
- if incomplete data is supplied, error 400 should be returned. 
- If incorrect url path is used to send the request, error 404 should be received.


 8. Order Webservice  (has a POST webservice and UI component)

- The Api accepts order details ie. movie id, seat_ids, customer information, promo id, total amount
- Proper data error validations should also be available in the UI. ie. verify for the completeness and formats of data
- The Api returns 200 if all data mandatory data are supplied
- if incomplete data is supplied, error 400 should be returned. 
- If incorrect url path is used to send the request, error 404 should be received.

 9. Payment and SMS Webservice (POST Request) - assuming that there are third-party gateways involved for payment and SMS Webservice passing of data should be secured. 
 
-  Validate that only api calls with complete data are accepted by the third-party service. 
- a correct response code and message should be received each time a service call is sent out.  

**Question 3**: 
The best approach would be to Stubs to simulate the responses from the third-party payment gateway. This way we will be able to test our own application with no dependency on the third-party gateway. 
