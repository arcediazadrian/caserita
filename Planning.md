# Planning
Thinking about how much time per week and overall duration
1. 6 hours per 2 months
2. Thinking about what things we want to showcase with the project
    - Showcase good practices and backend architecture
    - Showcase cloud platform integration (Firebase/Azure)
    - Showcase understanding of CI/CD (GitLab free tier)
    - Learn about AI
3. Thinking about project stages
    - Planning and estimation (see what goes in, what doesn't, what would be best for the first version)
    - Design
    - Implementation
    - Testing (BE: Postman, then FE: Atom?)
4. Thinking about what we will do exactly
	1. Personal finances
		1. Reader of invoices/receipts and data processing with AI
		2. Budgets
		3. Help in seeing where you're spending the most
		4. Integration with national banks
		5. Dynamic daily limit
	2. Shopping assistant
		1.  Reader of invoices/receipts and data processing with AI
		2. Reader of text/audio and data processing with AI
		3. Price comparison based on previous purchases and other people
		4. List creator and assistant to choose where to go based on where you live
    3. Eco-friendly Events Scraper
       1. Facebook event scraper
       2. Instagram event scraper
       3. Mobile app showing events and sending notifications for upcoming events 
Invoice/receipt reader
Audio/text reader
Expected outcome:
"hipermaxi"

|product|qty|price|
|--|--|--|
|milk|2|20|
|bread|4|4|
|paper|1|20|
|meat|1|35|

audio reader
AI module (LLM)
|product|qty|price
|--|--|--|
|milk|2|20|
|bread|4|4|
|paper|1|20|
|meat|1|35|

And then with the AI module (LLM)
convert it to JSON with a certain format

    {
    
	    "milk" : {
    
	    "quantity": 2,
    
	    "price": 20
    
    },
    
	    "rest of products":{}
    
    }

AI module
    4. Speech to technology diagram diagrams (PlantUML)
    5. Market creator and recipes with quantities (could be a module of b or its own application)
    6.  Efficient processing and simplification of text entered by the user to simplify the system.

## Planning
Planning hours so far: 10hx2

| EPIC     | FEATURE  | USER STORY  | TASK     |
|----------|----------|-------------|----------|
| 1. 2. 3. | i. ii. iii. | a. b. c. | a. b. c. |

Shopping assistant
1. Project setup
    1. Define Tech Stack | 8hx2
        1. Research technologies based on requirements
        2. Expose results to decide
        3. Create decision matrix as definitive output of research
    2. Decide application/project name | 15minx2
        1. caserita - Winner (temporary)
        2. casera
    3. Define BE Architecture
        1. Architecture research | 1.5hx2
            1. Adrian proposes presentation + business + data + domain
            2. Find out about Onion
            3. Find out what's trendy, if it seems interesting to delve a little
        2. Discuss architecture (layers) | 1hx2
        3. Define and document code standards | 1h
        4. Create a skeleton with the first entity | 2h
        5. Create folder structure | 0.5h
    4. Decide if we're going to use EF or not
        1. If we are going to use it, investigate if we are going to implement DB or Code First | 1h
        2. Discuss and decide on Code or DB First | 1hx2
        3. Implement a code example | 3h
    5. Implement a global exception handler | 3h
    6. Create unit test example (Moq, NUnit) | 1h
    7. Decide if we're going to use DB migrations or do them manually | 2h
        1. Research tools to apply migrations
        2. Create local script to run migrations
    8. Set up local environment
        1. Be able to download code and run it in an IDE | 10minx2
        2. For db use docker | 30minx2
        3. Connect to AI provider | 30min
    9. Set up cloud environment
        1. Access the cloud and initial configuration | 2h
        2. Create the DB server | 1h
        3. Create the BE function/server and confirm that some request works | 2h
        4. Connect to AI provider | 30min
    10. Identity Provider Research
        1. Research what tool we're going to use to handle user authentication | 2h
            1. Keycloak
            2. Azure AD/Entra ID
        2. Make a PoC of the tool | 8h
            1. Tool working locally (service and db)
            2. Create webpage to login or a postman endpoint or test
    11. Create pipeline to deploy code and db migrations. | 5h
2. Facebook Web Scraper Implementation
   1. Facebook Web Scraper (FWB) can search events based on eco-friendly keywords
      1. Research Web Scraping tools and decide what to use
      2. Research best ways to web scrape facebook for a specific topic
      3. Create FWB process that can be triggered by an http request
      4. Process should extract the event's text and format it into a standardized json structure
   2. BE API can save events sent from FWB
      1. Design Data Model for Event
      2. Create CRUD for Events
      3. Think about how we will check for duplicates and remove them (events can come from different sources and be duplicate, should that be tackled separately?)
      4. Filtering duplicates will require the BE to know where it came from and extra data like ids and urls to try to find duplicates, think about this topic and come up with a generic approach
   3. User can login into our mobile app.
      1. Research tool or service for user authentication.
      2. Implement simple user registration and authentication flow.
   4. Mobile app will show events gathered, have a link to the original post and notify users of upcoming events
      1. Create simple UI to show events
      2. Send notifications for new upcoming events
3. Instagram Web Scraper
4. Digital Newspaper Web Scraper
5. Think about other sources we could use

## Tech Stack

1. **Source Control. SaaS, Free, Public. MD support**
    1. **Github**
2. **Database. SQL or NoSQL. Nice to have. integrates well with code and has migrations (Entity Framework?, DB Migrations?)**
    1. **SQLServer**
3. **Map. Free, user can mark a place.**
    1. **Openstreet**
4. **Core Code.**
    1. **C# .NET.**
5. *AI Code. Hook up to the chosen AI provider. Promising libraries for handling LLMs and Computer Vision for the reader. Is Computer Vision the correct term for the reader?*
    1. *Python*
    2. *C# .NET*
6. *AI Provider. LLMs and Computer Vision Provider, Free/Low Cost*
    1. *OpenAI*
    2. *Google Gemini*
7. **Pipelines. Compatible with Source Control. Free Tier or can create an Agent. Compatible with Cloud would be a Nice To Have.**
    1. **Github Actions**
8. **Cloud. Free/Low Cost, DB, BE (Public URL with SSL [https://appName.webapp.firebase.io](https://appname.webapp.firebase.io/)), Auth provider would be a Nice to Have**
    1. **Azure**
9. **Board. Free and Public would be a Nice to Have**
    1. **Trello**

AI Provider and Cloud assume a possible investment. Maximum during project lifetime $200.

**Done**
*Both*

> Paulo

     Adrian

Flow

I register in the application for the first time and it shows me the decision of public and private purchases.

(Some notes)

/api

–/presentation

–/sql

—-/V1_09042024_InitialEntities.sql

—-/V2_09052024_LocationEntity.sq

flyway

docker run flyway -url -pass -v ./api/sql

create table user

create table settings

add constraint user foreign key settings

remove foreign key user_settings

create table location
