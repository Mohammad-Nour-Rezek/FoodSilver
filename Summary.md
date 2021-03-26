### Food Silver

web ui
data access(entities)
unit test
domain bussiness logic(view models)


msbuild tool
build to assembly

firefox will see the self signed certificate that com with the first request to the IIS server and block it for SSL security

add two abstraction options and that done using namespacese so we need to create folders for each one
- category 1 - classes define shape of data (Models or entities that represent the database)
- category 2 - servicese used to access data

add abstraction to simulate data access to database (servicese using interfaces)

add reference to other proj

initialize service using interface and type (we will use insted DI in feuture to void 'new' KW)

--------------

- disolay a message from a configuration file and configure the dependecies

after build the project will get --> foorSilver.web.dll assembly for each project we have contain the compilation result of .cs and js and another files it's contain exe code in MSIL format, the file .dll deos not know how to lessen to web socket that use http from web browser it need web server infrastructure so will start a web server IIS that will host this file and map the http request to this file 


- Global.asax : is the startup file when the application start, we can see it's markup
- when we start the application this file tell mvc to instantiate this class Inherits="FoodSilver.Web.MvcApplication"
- now for ex. when we call the static method 'RegisterBundles' it will register all the routes inside this collection 'BundleCollection' and when the browser call the route will get the minified version like: https://localhost:44373/Content/css
- we add routes to the 'RouteCollection' that tells the mvc what to do with each route request
- in addition to .cs configuration files there is one important XML based config file 'Web.config' and inside of it there is:
  - bindingRedirect: to use another version of assembly if the othe is not exist
    - compiler: config for .cs and .vb files
    - targetFramework: that is .net 4.7.2
    - appSettings: here we can put any setting like: UnobtrusiveJavaScriptEnabled, ClientValidationEnabled for front end.
      - so here we cant tell the app what db to use, what message queue to use, address for other web service that the app need to use
        - so every app setting need a key and a value for ex.: "<add key='message' value='hello' >" and we can reach this value using configurationmanager.appsitting['key'] dictionary
- Dependency Injection: to use the inversion of controll princeaple of SOLID we will inject a type that implement the service insted of we instantiate it hard coding and let the controller depend on that object who implement it so we need Inversion of Controll container this container know how to build and analyse objects like HomeController to understand what dependencies are requiered and what to inject when the controller say's please give me an object implement this high level object instance HomeController(IRestaurantData db) so we will configer IoC container to instantiate the controller and pass the parameter to it
  - we will add on this proj ref the nuget autofac.mvc5 pkg
  - now we will ad a .cs config for the container

- in web api there is no action specify in the url and this is the diffirance to regular
  - the actions is: Get, Post, Put, Delete
  - system.web.http is the primary namespace for api

- we can see all packages in packages.config

- we can try this in postman, and we can try this in command prompt using: curl https://localhost:44373/api/restaurants -H "Accept: application/json" /\/\/\/\/\ or xml, H for header

- if we change the route id to key in the config the mvc will try to make url to the Details link so it will put the id in the query string

- view model: doing all operations on data that need to render in the view, so may be the view need data from more than one entity or [model] so view model is prepare the data needed for the view
- 'CSRF' Cross-site request forgeries using AntiForgeryToken, if site require authentications and use cookies

- if we post a req to a controller without a post action result will get the same get action result, the form method property will be the same url of the create page

- when request is send to server for post mvc will understand that it look for object of type Restaurant and it has id, name, cuisine and to bind these properties it search for name='' prop in the html element and the value associated with it, this process known as model binding

- post-redirect-get pattern to avoid stay in the same page
- duplicate transaction: if the user send a post req and still in the same page and his information still in the form, when he reload the page the browser wil ask him to resend the information again

- localDB: installed with VS and it's a real sql server db but not for production
  - to use: 1- check if it exist using developer vs command prompt: sqllocaldb, sqllocaldb i [[for db instance information]], sqllocaldb i mssqllocaldb [[more information]]
  - we can see it in the sql server object explorer 

- to install EF use Nuget and install it in the two projects so right-click on the solution and do it ..., see package.config and web.config [ConfigSection, entityFramework]

- DbContext: is EF base class and gate way to db

- because i expext the req com from a browser so just 2 http verbs are needed: Get, Post, when i work with api i will need other verbs