Database structure:

- User – Stores name and phonenumber
- Interest – stores title and description
- Link – Stores url connected to both user and interest
- A user can have many interests (many-to-many)
- A link is allways connected to both a user and an interest

API structure:

User
----------------------------------

GET /api/User/GetAllUsers: 

Get all users in the database.

----------------------------------

POST /api/User/{userId}/interests{interestId}

Connect a user to an interest by user ID and interest ID.

-----------------------------------

POST /api/User/AddNewUser:

Add a new user to the database by entering name and phonenumber.

-----------------------------------

DELETE /api/User/{id}

Deletes a user from the database by entering user ID.

-----------------------------------

Interest
-----------------------------------

POST /api/Interest/AddNewInterest

Adds a new interest to the database by entering title and description.

-----------------------------------

GET /api/Interests/GetAllInterests

Gets all the interests in the database.

-----------------------------------

GET /api/Interest/{userId}

Get all interests connected to a specific user by entering user id.

-----------------------------------

DELETE /api/Interest/{id}

Deletes an interest from the database by entering interest ID.

-----------------------------------

Links
-----------------------------------

POST /api/Link/{userId}/{interestId}

Add new link to specific user and specific interest by entering user ID, interest ID and url for the link.

-----------------------------------


GET api/Link/{userId}

Get all links connected to a specific user by entering user id.

-----------------------------------

GET api/Link/GetAllLinks

Gets all the links in the database.


