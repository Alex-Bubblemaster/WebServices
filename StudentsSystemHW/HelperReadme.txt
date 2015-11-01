Register the first user:

{
  "username": "batman",
  "email":"batman@marvel.com",
  "password": 123456,
  "confirmpassword": 123456
}

Few students are seeded in the Database - you should make GET requests, also GET by id (i.e Students/1)
Also provided are DELETE, PUT and POST(Check out the controllers ->Server/StudentSystem.Api/Controllers) for full list

http://localhost:****/api/Students
http://localhost:****/api/courses
http://localhost:****/api/homeworks
http://localhost:****/api/students


The DB generates a model with AspNetUsers table in the DB. You should be able to find batman there.
The connection string is in the webconfig file. For SQL 2014 it is : 
  <connectionStrings>
    <add name="DefaultConnection" connectionString="Data Source=.;Initial Catalog=StudentSystem;Integrated Security=True"
      providerName="System.Data.SqlClient" />
  </connectionStrings>

Access token expiration is two months
  
G7v7uPQ5sQCSxheTOTMg2rHlcDmKnBrEtOlMFVfWlXAEhQ67nGNwvX2AUOPCp12nW2kjR3d0WlMSutS5CKJLQy8e9HDYoQVp1Qndt-8SRBht-w_q0gijo2ehA5VAzSwtpv0Owi5FLu6cyA3YAfEwEWz_CqUatqBulmWuxexGRbW9lMh5-uncMtdHazzRd-qro1vEnqGchn61CkwyhCHfFwM-9crAL9V4_h-gae2XNG666nPKCfO2meBjtqJsnTanuMmD4DOtgIhZXbtyCchitQ7knaSXXOFl9DaUVEAL7kiVhDEU6VLNqUXSMyxTNo4bR3RiEkLzNVoo8RPRLT7CicXSNoPfwNVtQprH8ZGipbMj4NjL79RsGccCbfmNl3HTYNXBxTdwTCYSwDGWteXrdLbzSzQe7L9a2hP__8niPoATXPny0_aPF81w5R5kpnEBsL7YfeYV4z1I9R3fAs4_W-qYpNxF2rbGW29RcFU70d5n43g9qnI6WLpt-Thsm4un

This are sample posts for requests - Content-Type application/json

Homeworks controller
{
   "CourseId":3,
   "StudentIdentification": 2,
   "FileUrl": "www.9gag.com"
}

Courses controller
{
    "Id": 1,
    "Name": "Updated course",
    "Description": "Another course for testing"
}