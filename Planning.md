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
3. Speech to technology diagram diagrams (PlantUML)
4. Market creator and recipes with quantities (could be a module of b or its own application)
5.  Efficient processing and simplification of text entered by the user to simplify the system.

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
    8. AI Provider PoC | 4h
    9. Set up local environment
        1. Be able to download code and run it in an IDE | 10minx2
        2. For db use docker | 30minx2
        3. Connect to AI provider | 30min
    10. Set up cloud environment
        1. Access the cloud and initial configuration | 2h
        2. Create the DB server | 1h
        3. Create the BE function/server and confirm that some request works | 2h
        4. Connect to AI provider | 30min
    11. Identity Provider Research
        1. Research what tool we're going to use to handle user authentication | 2h
            1. Keycloak
            2. Azure AD/Entra ID
        2. Make a PoC of the tool | 8h
            1. Tool working locally (service and db)
            2. Create webpage to login or a postman endpoint or test
    12. Create pipeline to deploy code and db migrations. | 5h
    13. LLMs PoC | 6h
        1. Use GPT 3.5 Turbo
        2. Do a small test for point 3.a.iii in Python.
    14. OCR/Computer Vision PoC | 4h
        1. Use Azure OCR/Document Intelligence/AI Vision
        2. Be able to take a photo of a receipt and recognize the text
        3. If it can put it in JSON format directly it's a plus
2. Price comparison based on previous purchases and other people. List creator and assistant to choose where to go based on where you live
    1. I can register in the application and log in with my credentials.
        1. Design data model for application user | 2h
            1. Data that the user will enter on the platform like name, email, setting id, gender, dob, etc
            2. Present idea and apply feedback
            3. Implement data model in DB
        2. CRUD for user | 3h
            1. Implement entity in code
            2. Implement layers (controller, service, repo)
        3. Integrate application with Login (For later, possibly mid-project)
    2. I can choose if my purchases will be public or private (this affects the data with which purchases are compared)
        1. Design user settings data model | 1h
            1. Settings that the user will enter on the platform.
            2. Present idea and apply feedback
            3. Implement data model in DB
        2. CRUD for settings | 2h
            1. Implement entity in code
            2. Implement layers (controller, service, repo)
        3. Think about how settings will be passed to all modules that need them | 4h
            1. Present idea
            2. Apply an example
    3. I can create a list of purchases **made** with prices, quantities, and location.
        1. Design data model for shopping lists
        2. Design data model for place (lat,long,name)
        3. Design data model for product (it may be useful to have a category)
        4. CRUD for place (for dropdown search or an internal service)
        5. CRUD for product
        6. CRUD for list data
        7. The place will be a pin on the map, figure out how we'll deal with nearby pins and how we'll indicate to the user the name of the market of the approximate location
        8. Consider if the made vs desired shopping list is the same and if we can reuse it.
        9. Think about how to handle different quantities (units, gr, kg).
        10. Think about how to handle different ways of putting the same product (possibly using LLMs).
1kg of meat
1000g of cow meat
2 pounds of cow’s back
fourth of eggs
4 egg package

	 3. Create a **desired** shopping list.
        1. Design data model for shopping lists
        2. Design data model for product (it may be useful to have a category)
        3. CRUD for product
        4. CRUD for list data
	  4. The application will give you a summary after finishing a purchase by evaluating against previous purchases.
	        1. Design data model for comparison summary.
	        2. Implement purchase comparator.
	        3. I want to know if the price went up.
	        4. I want to know if I got ripped off.
	        5. Solve the problem of how to process new global data once and then be able to access the processed data with price averages.
	        6. For now, we've decided not to save the summary, just to display it. Reconsider when we get to this point.
	  5. The application compares prices with past purchases and recommends a place.
	        1. Design data model for comparison.
	        2. Implement purchase comparator.
	        3. I want to know where it will be cheapest to buy the items on my list.
	        4. I want it to give me 3 default place recommendations.
	        5. I want it to order the places from cheapest to most expensive (maybe include distance in the result).
	        6. Solve the problem of how to process new global data once and then be able to access the processed data with price averages.

1. Invoice/receipt reader and data processing with AI
    1. I can scan or take a photo of an invoice/receipt for the application to generate a list automatically.
        1. Implement Image to Text reader.
        2. Design intermediate data model between the shopping list and the invoice
        3. Implement LLM to erase all unnecessary text, and convert the invoice data to the intermediate data model.
2. Text/audio reader and data processing with AI | Nice to have
3. Automated list creation based on previous purchases | Nice to have
4. Suggestion of how much product is needed based on people or portions | Nice to have

Note: We have to see how we handle metric units

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
