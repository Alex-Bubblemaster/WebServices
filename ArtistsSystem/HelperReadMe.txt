Once you build the app, you can run it. I set it so that the console client and web client start simultaneously.
No UI so it will have to be Postman to test it. 
I am using SQL 2014 so you may have to change the connection string.
Some data will be seeded and database created so you can skip the trouble to have to register a user.
I left all operations unauthorized for easy testing.

Genres and Countries template is the same:

{
    "Name": "Spain"
}

Songs (Post format)

{
	"Id": 2,
	"Title": "We will rock you",
	"Year": 1977,
	"ArtistName": "Queen",
	"ArtistId": 2,
	"GenreName": "Rock",
	"AlbumName": "Golden Hits"
}

Albums (PostFormat)
{
    "Id": 10,
    "Title": "Ain't nobody got time for that",
    "Year": 2012,
    "Producer": "Sweet Brown"
}

Artist is really complex so I only used GET requests as it was not a requirement to have CRUD for each and everyone