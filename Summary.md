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
  - - bindingRedirect: to use another version of assembly if the othe is not exist
    - compiler: config for .cs and .vb files
    - targetFramework: that is .net 4.7.2
    - appSettings: here we can put any setting like: UnobtrusiveJavaScriptEnabled, ClientValidationEnabled for front end.
      - so here we cant tell the app what db to use, what message queue to use, address for other web service that the app need to use
        - so every app setting need a key and a value for ex.: "<add key='message' value='hello' >" and we can reach this value using configurationmanager.appsitting['key'] dictionary