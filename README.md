# Galvanize Dealership App

### Users can:

>Submit vehicles using valid 17 character vin.

>View Dealership inventory.

>Messages admins.

### Admins can:

>View submitted vehicles.

>Approve submitted vehicles to be view by all users.

>View messages sent by users.

>Submit vehicles using valid 17 character vin.

>Created and delete rules for desires vehicles.



### Docker containers created:

=========================================================

.NET API server

Node.js API server

2 ReactJS SPA - One connected to dotnet api, the other connected to the node api

MongoDB database

MongoDB Express

=========================================================

Repository contains sub-repositories for React App and Node API.

# Currently newly created users must be manually set as admins using Mongo Express by setting isAdmin property to "true".


