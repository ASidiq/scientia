# README

# Avanade Fundamental Project

---

This readme file serves as my documentation for the Avanade fundamental project I worked on. 

The object of the project is to:

- create a CRUD application with the utilisation of supporting tools, methodologies and technologies that encapsulate all core modules covered during training.

The idea for the project can be a business case, such as a library or supermarket system, or something to do with a hobby of yours.

This is purposefully open to endorse creativity and allow us to do a project that we have full command over. It is in our interest do something we are passionate about, as experience has shown these to be the best projects.

# Scientia Bookstore Management System

---

# Introduction

Every step of the software development cycle responsible for making Scientia possible is detailed within this document. Scientia is a bookstore management system, deployed as a web application, that aides bookstores in managing their catalogue of items. It enables the adding and deleting of books from the bookstore's database. Furthermore, it ensures bookstores are able to update any of their book's information be it the published date, author, number of copies etc.

# Requirement

There were a  list of requirements the project  had to adhere to. They can be found in the image below

![README/Untitled.png](README/Untitled.png)

From the requirements, I determined what the minimum viable version of my application would be and how it satisfies the CRUD requirements provided above. See the bullet list for the details. The application must:

- `provide a view of the entirety of the booskstore's catalogue of books` - This satisfies the "read" portion of the crud requirement
- `enable the addition of books to the bookstore's catalogue` - This satisfies the "create" portion of the crud requirement
- `enable the deletion of books from the bookstore's catalogue` - This satisfies the "delete" portion of the crud requirement
- `enable the updating of books in the bookstore's catalogue` - This satisfies the "update" portion of the crud requirement

Ideally, interviews or surveys will be conducted to understand what a bookstore manager would need need from a bookstore management system. However, due to time constraints, I played the role of this stakeholder. A Trello board was created to make tracking of these features and managing the project easy.

# Risk Assessment

The risk assessment matrix below describes the potential risks identified throughout the life of the project. In addition to each risk, It also includes the likelihood of the said risk happening, the severity of the risk if it does happen and the measure put in place to control the impact of the risk. A revisit column was added to ensure that each risk is re-evaluated continuously throughout the project and importantly in light of the current state of the project at the time of evaluation. 

![README/Untitled%201.png](README/Untitled%201.png)

# Architecture, Design and Tools

An MVC software design pattern will be used in building Scientia. The "M" in MVC stands for model and the app's model will be defined using C#. The project will use a MySQL database and it will be created using a code-first development approach through the use of Entity Framework. "V" refers to view which is the front-end of the application. Scientia's front end will be built using the Angular framework which comprises of HTML+CSS for structuring and styling the app's webpage, and Typescript for writing the views logic. The "C" refers to the controller and it takes requests from the front-end and serves it to the back-end, and also takes results/responses from the back-end and serves it to the front-end to display. The controller implemented for this project will be a .NET 5 Web API written in C#.

![README/Untitled%202.png](README/Untitled%202.png)

## Model - Database's Entity Relationship Diagram

![README/Untitled%203.png](README/Untitled%203.png)

The image above shows the entity relationship diagram (ERD) for the database required by the mvp version of the application. Within each entity which maps to a table within the database, the diagram shows which field is the primary key (denoted by "PK"), it shows all the fields in the table, and lastly, the type of data stored for each field. In addition, the ERD shows the most important feature of all, the relationship between entities/tables. The relationship from the book to the author entity is one-to-one. This means the a book can only belong to a single author and a single author only. However, the relationship from author to the book is that of a many-to-one. This means that the author can author many books. This model is indeed simplified as in the real world the relationship describe is not so, however it forms a good base to have a minimum viable version of my application built on top.

## Controller - .Net Web API

A .Net 5 Web API app was used as the controlller for Scientia and it handled the http requests required to ensure the application can carry out all the required crud operations. 

For the Book model the controller is able to handle:

- GET requests - read
- POST requests - create
- PUT requests - update
- DELETE requests - delete

![README/Untitled%204.png](README/Untitled%204.png)

For the Author model the controller is designed to handle only GET, PUT and DELETE,  and this is because Scientia was designed in a way that a book must have an author. Therefore, when a book is created, the author detail must also be provided and the author is created along with the book. Similarly, an author connected to a book cannot be deleted which is consistent with the desired between an author and a book.

## View

The Application's UI was built using a front-end framework called Angular and some additional libraries e.g. angular material bootstrap.

The front end comprises of a home page view, a view for viewing all the books in bookstore's catalogue, a view for creating a book , a view with all the authors who have authored books in the bookstore's collection, a view for deleting and updating a book's information, and a last view for deleting and updating authors

The view below is the home page and it consists of the application's name to the top left, a "Home" navigation button to be used to return to this view from other views, and a services drop menu to access other services within the application.

![README/Untitled%205.png](README/Untitled%205.png)

This view enables the bookstore staffs to add books to the bookstore's catalogue. The view takes details such as the book's title, author's name genre etc. All fields have to be completed and with valid values before the "Add button" is enabled. For example if either the book cover url or the author profile pic url do not point to an image then the form cannot be submitted. Similarly, ratings needs to be between 1 and 10 before the form can be submitted.

![README/Untitled%206.png](README/Untitled%206.png)

This view enables users of the application to view the books with the bookstore's catalogue. The search field can be used search for specific text across the different columns. The view also contains a paginated table with makes it less cluttered. 

![README/Untitled%207.png](README/Untitled%207.png)

In the view directly above, the title of the book is a link and it directs users to the view below, where they can either choose to update the book's details or delete it. Similar to the view where a book can be created, the fields in the view below must pass some validation criteria before the info can be submitted. Also, the form is pre-filled with the books current details making it easier for the user to modify it appropriately.

![README/Untitled%208.png](README/Untitled%208.png)

The last two views enable users to view the authors of book within the catalogue and also modify the profile of the or delete the author, however the delete operation is only successful is the author is not attached to a book.

![README/Untitled%209.png](README/Untitled%209.png)

![README/Untitled%2010.png](README/Untitled%2010.png)

## Services

A shared services class was created within the angular application and its purpose was to make request to the API and get the response to the components in need of the information within the front end. As a result, the methods mirrored that found within the C# API application.

```tsx
//Books APIs
  getEntireCatalogue(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/books');
  }

  getBook(title: string): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + `/books/${title}`)
  }

  addBook(bookDetails: any) {
    return this.http.post(this.APIUrl + '/books', bookDetails);
  }

//Author APIs
  getAllAuthors(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/authors');
  }

  getAuthor(title: string): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + `/authors/${title}`)
  }

  updateAuthor(authorDetails: any, authorID: number) {
    return this.http.put(this.APIUrl + '/authors/' + authorID, authorDetails);
  }
```

The functions use an observer pattern. Which means that any dependent that subscribe to this function using the the ".subscribe()" method will get notified when the state of the subject (the functions above) change. This allows data to flow asynchronously into the view.

## Versioning Control

Git and GitHub were, respectively, the versioning tool and versioning tool vendor used within this project. The feature-branch model was adhered during to the development coding phase. This means that each feature which maps to a user story was implemented in its own Git branch and then merged on completion to the main branch. The feature-branch model ensures that the main branch will not contain broken code. Within a large team, it provides  then opportunity for multiple developers to work on a particular feature without disturbing the main codebase. 

![README/Untitled%2011.png](README/Untitled%2011.png)

# Testing and CI/CD

## Test

Testing is an important part of developing any software as it help ensures most bugs don't reach production and that the software /applications performs the desired functions as intended. Scientia's back-end was thoroughly tested; virtually all the methods that performed some form of computation within them were tested (the controllers and the utility classes). 

The API methods were tested by mocking the function of the methods and the methods were made testable by implementing them using a repository pattern.  By combining mocking with repository Test Driven Development can be practicalized . In addition to mocking and the repository pattern, the Arrange-Act-Assert pattern was also used for writing every test. The Arrange section involves setting up the variables and classes needed to test a method. The Act phase is where the method is used as it normally would. Within the Assert phase, we check to confirm that the result of the method is what is desired.

```tsx
				[Fact]
        public void GetAllBooksTest()
        {
            //Mocking
            //Arrange
            mockRepo.Setup(repo => repo.Books.FindAll(b => b.Author)).Returns(GetBooks());

            //Act
            var controllerActionResult = booksController.GetAllBooks();

            //Assert
            Assert.NotNull(controllerActionResult);
           
        }

				[Fact]
        public void GetViewModel()
        {
            //Arrange
            Book newBook1 = new Book()
            {
                ID = 8,
                CreatedAt = DateTime.Now,
                BookPictureUrl = "https://avatars.githubusercontent.com"
																			"/u/38431581?s=60&v=4",
                Title = "The Gods Are Not to Blame",
                PublishedDate = 2005,
                Type = "Fiction",
                Genre = "Fantasy",
                Location = "UK",
                TotalPages = 500,
                Rating = 10,
                Copies = 5
            };

            //Act
            var testBookViewModel = newBook.GetViewModel();

            //Assert
            Assert.IsType<BookViewModel>(testBookViewModel);
            Assert.NotNull(testBookViewModel);
            Assert.NotEmpty(newBook.Title);

        }
				
```

Test reports are important as they provided insight how well an application is tested known as code coverage and what parts of the application need more testing. For Scientia, Coverlet, a cross platform code coverage framework for .NET along with a commandline tool called ReportGenerator were used to generate the test report for Scientia's backend. On average 84% of the 4 classes tested were covered, see result in the file attached. The complete result can also be found in the repo (ScientiaWebAPI → ScientiaTest → TestResults → index)

[index.html](README/index.html)

# Continuous Integration and Continuous Deployment

Continuous Integration and and continuous deployment are both key cogs within DevOps and the involve automating the process of building, testing and deploying an application to which environment it is needed. The image below details the CI/CD pipeline used in deploying my Web API to an Azure App Service.

![README/Untitled%2012.png](README/Untitled%2012.png)

The CI/CD pipeline begins with me pushing my code to the main branch of my GitHub repository. Through the use of a service hook, Azure DevOps connected to the repository observes the change/commit and triggers the pipeline attached the repository as per the trigger assigned in the YAML file (- main). As I did not have access to a Microsoft hosted agent, I had to setup a self-hosted build agent on a virtual machine. When the pipeline is ready to execute the jobs in the YAML file they are send and processed by the self-hosted agent. This pipeline is divided into two stages, a build stage and a release stage. Within the build stage, the agent:

- installs NuGetTool
- restores the API program files
- builds the files (code becomes an artefact)
- runs the tests
- publishes the coverage result
- publishes the project (application)
- publishes the artefact

During the release stage, the agent:

- downloads the built artefact
- takes the artefact and deploys it to Azure App service.

In addition, because the test and report generator are ran as part of the pipeline and published a code coverage report is also attached to the particular run.

![README/Untitled%2013.png](README/Untitled%2013.png)

![README/Untitled%2014.png](README/Untitled%2014.png)

# Future Works

Due to time constraints, there were are a number of features not implemented within this very first version of Scientia. Within the model section of the docs, I mentioned that the relationship of the a book with an author is one to one only. We know this false as a book can have multiple authors, but the simplification had to be done to ensure an mvp that met the project requirements could be built. In the future, Scientia can be improved to better model the relationship between books and authors in the real world.

![README/Untitled%2015.png](README/Untitled%2015.png)

In future versions of Scientia, the application's model will look more like above. Because the relationship between a book and author is a many-to-many an intermediate table will be needed so that we can create a database for the entities in MySQL.

Another feature that will be coming to Scientia is its integration with a bookstore's checkout system. This will enable Scientia to update the bookstore's catalogue based on the books purchased. Also for specific institutions like a libraries, Scientia can be designed to enable the library users to loan and return books to the library.