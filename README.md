Database structure:

- User – Stores name and phonenumber
- Interest – stores title and description
- Link – Stores url connected to both user and interest
- A user can have many interests (many-to-many)
- A link is allways connected to both a user and an interest

API structure:

User

GET /api/User/GetAllUsers: 
- Get all users in the database.
Ex response body:
{
    "id": 10,
    "name": "Svampbob Fyrkant",
    "phoneNumber": null
  },
  {
    "id": 11,
    "name": "Patrik Stjärna",
    "phoneNumber": "0711001010"
  }

----------------------------------

POST /api/User/{userId}/interests{interestId}
- Connect a user to an interest by user ID and interest ID.
Ex response body:
Intrest 'Fishing' added to user: Robin Johansson

-----------------------------------

POST /api/User/AddNewUser:
- Add a new user to the database by entering name and phonenumber.
Ex response body:
{
  "id": 14,
  "name": "John Doe",
  "phoneNumber": "0123456789",
  "interests": [],
  "links": []
}

-----------------------------------

DELETE /api/User/{id}
- Deletes a user from the database by entering user ID.
Ex response body:
User deleted.

-----------------------------------

Interest

POST /api/Interest/AddNewInterest
- Adds a new interest to the database by entering title and description.
Ex response body:
{
  "id": 16,
  "title": "Tennis",
  "description": "Playing tennis",
  "users": [],
  "links": []
}

-----------------------------------

GET /api/Interests/GetAllInterests
- Gets all the interests in the database.
Ex response body:
{
    "id": 9,
    "title": "Music",
    "description": "Playing music"
  },
  {
    "id": 10,
    "title": "Bicycles",
    "description": "Riding bicycles"
  }

-----------------------------------

GET /api/Interest/{userId}
- Get all interests connected to a specific user by entering user id.
Ex response body:
  {
    "id": 11,
    "title": "Drawing",
    "description": "Drawing pretty colorful pictures"
  },
  {
    "id": 12,
    "title": "Sports",
    "description": "Playing sports"
  }

-----------------------------------

DELETE /api/Interest/{id}
- Deletes an interest from the database by entering interest ID.
Ex response body:
Interest deleted.

-----------------------------------

Links

POST /api/Link/{userId}/{interestId}
- Add new link to specific user and specific interest by entering user ID, interest ID and url for the link.
Ex response body:
{
  "id": 20,
  "url": "www.google.com",
  "userId": 9,
  "interestId": 13
}

-----------------------------------


GET api/Link/{userId}
- Get all links connected to a specific user by entering user id.
Ex response body:
{
    "id": 14,
    "url": "www.spotify.com"
  },
  {
    "id": 17,
    "url": "www.netflix.com"
  }
-----------------------------------

GET api/Link/GetAllLinks
- Gets all the links in the database.
Ex response body:
 {
    "id": 17,
    "url": "www.netflix.com"
  },
  {
    "id": 18,
    "url": "www.youtube.com"
  }

